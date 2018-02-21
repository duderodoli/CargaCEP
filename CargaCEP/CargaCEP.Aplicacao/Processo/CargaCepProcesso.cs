using CargaCEP.Dominio.DTO;
using CargaCEP.Dominio.Processo;
using CargaCEP.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Transactions;

namespace CargaCEP.Aplicacao.Processo
{
    public class CargaCepProcesso : ICargaCepProcesso
    {
        private readonly IBairroRepositorio _bairroRepositorio;
        private readonly ILocalidadeRepositorio _localidadeRepositorio;
        private readonly ILogradouroRepositorio _logradouroRepositorio;        

        private List<string> estados = new List<string>() {
                                                    "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA",
                                                    "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"
                                                  };
        private List<String> mensagemErro;
        private BackgroundWorker bw;
        public void ExecutarSincronizacaoCep(string filePath, List<String> mensagem, BackgroundWorker backGroundWorker)
        {
            mensagemErro = mensagem;
            bw = backGroundWorker;

            mensagemErro.Clear();
            mensagemErro.Add("COMEÇO");
            bw.ReportProgress(0);       
           
            try
            {
                ZipArchive archive = ZipFile.OpenRead(filePath);
                archive.CreateEntry("DNE_CORREIOS" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year);
                archive.ExtractToDirectory("DNE_CORREIOS" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year);

                if (ValidarCarga(archive))
                {
                    mensagemErro.Add("VALIDAÇÃO CORRETA");
                    Sincronizar(archive);
                }
                else
                {
                    mensagemErro.Add("VALIDAÇÃO INCORRETA");
                    bw.ReportProgress(0);
                }
            }
            catch(Exception ex)
            {
                mensagemErro.Add(ex.Message);               
            }                                  
        }

        public CargaCepProcesso(IBairroRepositorio bairroRepositorio, ILocalidadeRepositorio localidadeRepositorio, ILogradouroRepositorio logradouroRepositorio)
        {
            _bairroRepositorio = bairroRepositorio;
            _localidadeRepositorio = localidadeRepositorio;
            _logradouroRepositorio = logradouroRepositorio;
        }
        
        private bool ValidarCarga(ZipArchive archive)
        {
            return (ProcurarLeiaMe(archive) & ProcurarLogBairro(archive) & ProcurarLogLocalidade(archive) & ProcurarLogradouros(archive));
        }

        private bool ProcurarLeiaMe(ZipArchive archive)
        {
            if(!archive.Entries.Any(a => a.FullName.Equals("LEIAME.TXT", StringComparison.InvariantCultureIgnoreCase)))
            {
                mensagemErro.Add("Arquivo \"LEIAME.TXT\" não encontrado ou localizado fora do padrão");                
                return false;
            }
            return true;
        }

        private bool ProcurarLogBairro(ZipArchive archive)
        {
            if (!archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_BAIRRO.TXT", StringComparison.InvariantCultureIgnoreCase)))
            {
                mensagemErro.Add("Arquivo\"Delimitado/LOG_BAIRRO.TXT\" não encontrado ou localizado fora do padrão");   
                
                return false;
            }
            return true;
        }

        private bool ProcurarLogLocalidade(ZipArchive archive)
        {
            if (!archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOCALIDADE.TXT", StringComparison.InvariantCultureIgnoreCase)))
            {
                mensagemErro.Add("Arquivo \"Delimitado/LOG_LOCALIDADE.TXT\" não encontrado ou localizado fora do padrão");                
                return false;
            }
            return true;
        }

        private bool ProcurarLogradouros(ZipArchive archive)
        {
            bool retorno = true;
            foreach (String uf in this.estados)
            {
                if (!archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOGRADOURO_" + uf + ".TXT", StringComparison.InvariantCultureIgnoreCase)))
                {
                    mensagemErro.Add("Arquivo \"Delimitado/LOG_LOGRADOURO_" + uf + ".TXT\" não encontrado ou localizado fora do padrão");                   
                    retorno = false;
                }
            }
            return retorno;
        }

        private void Sincronizar(ZipArchive archive)
        {
            List<BairroDto> listaBairros = CarregarBairros(archive);

            List<LocalidadeDto> listaLocalidades = CarregarLocalidades(archive);

            List<LogradouroDto> listaLogradouros = CarregarLogradouros(archive);

            using (var transacao = new TransactionScope())
            {
                try
                {

                    mensagemErro.Add("INSERINDO BAIRROS");
                    bw.ReportProgress(0);
                    _bairroRepositorio.InserirBairros(listaBairros.ConvertAll(dto => dto.CriarEntidade()));
                    mensagemErro.Add("INSERÇÃO DE BAIRROS FOI UM SUCESSO");
                    mensagemErro.Add("INSERINDO LOCALIDADES");
                    bw.ReportProgress(0);
                    //_localidadeRepositorio.InserirLocalidades(listaLocalidades.ConvertAll(dto => dto.CriarEntidade()));
                    mensagemErro.Add("INSERINDO LOGRADOUROS");
                    //_logradouroRepositorio.InserirLogradouros(listaLogradouros.ConvertAll(dto => dto.criarEntidade()));
                    transacao.Complete();
                }
                catch (Exception ex)
                {
                    mensagemErro.Add(ex.Message);
                    bw.ReportProgress(0);
                } 

                
            }
        }

        private List<BairroDto> CarregarBairros(ZipArchive archive)
        {
            List<BairroDto> listaBairros;
            if (archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_BAIRRO.TXT")))
            {
                listaBairros = CarregarArquivo<BairroDto>(archive.GetEntry("Delimitado/LOG_BAIRRO.TXT"));
            }
            else
            {
                listaBairros = CarregarArquivo<BairroDto>(archive.GetEntry("Delimitado/LOG_BAIRRO.txt"));
            }

            return listaBairros;
        }

        private List<LocalidadeDto> CarregarLocalidades(ZipArchive archive)
        {
            List<LocalidadeDto> listaLocalidades;
            if (archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOCALIDADE.TXT")))
            {
                listaLocalidades = CarregarArquivo<LocalidadeDto>(archive.GetEntry("Delimitado/LOG_LOCALIDADE.TXT"));
            }
            else
            {
                listaLocalidades = CarregarArquivo<LocalidadeDto>(archive.GetEntry("Delimitado/LOG_LOCALIDADE.txt"));
            }

            return listaLocalidades;
        }

        private List<LogradouroDto> CarregarLogradouros(ZipArchive archive)
        {
            List<LogradouroDto> listaLogradouros = new List<LogradouroDto>();

            foreach (String uf in this.estados)
            {
                if (archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOGRADOURO_" + uf + ".TXT")))
                {
                    listaLogradouros.AddRange(CarregarArquivo<LogradouroDto>(archive.GetEntry("Delimitado/LOG_LOGRADOURO_" + uf + ".TXT")));
                }
                else
                {
                    listaLogradouros.AddRange(CarregarArquivo<LogradouroDto>(archive.GetEntry("Delimitado/LOG_LOGRADOURO_" + uf + ".txt")));
                }
            }

            return listaLogradouros;
        }

        private List<T> CarregarArquivo<T>(ZipArchiveEntry caminho) where T : BaseDto
        {
            List<T> listaBase = new List<T>();
            try
            {
                using (StreamReader sr = new StreamReader(caminho.Open(), System.Text.Encoding.GetEncoding(1252)))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var novoBase = (T)Activator.CreateInstance(typeof(T), new object[] { line.Split('@') });
                        listaBase.Add(novoBase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return listaBase;
        }
    }
}
