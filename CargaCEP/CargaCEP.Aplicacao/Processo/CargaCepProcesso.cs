using CargaCEP.Dominio.Processo;
using CargaCEP.Dominio.Repositorio;
using CargaCEP.Dominio;
using System;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargaCEP.Dominio.DTO;
using System.IO;

namespace CargaCEP.Aplicacao.Processo
{
    public class CargaCepProcesso : ICargaCepProcesso
    {

        List<string> estados = new List<string>() {
                                                        "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA",
                                                        "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"
                                                      };

        public void ExecutarSincronizacaoCep(string filePath)
        {            
            ZipArchive archive = ZipFile.OpenRead(filePath);            
            if (validarCarga(archive))
            {
                sincronizar(archive);                
            }
        }

        //public CargaCepProcesso(IArquivoImportacaoRepositorio arquivoImportacaoRepositorio)
        //{
        //   _arquivoImportacaoRepositorio = arquivoImportacaoRepositorio;
        //}
    

        private bool validarCarga(ZipArchive archive)
        {     
            return (
                    archive.Entries.Any(a => a.FullName.Equals("LEIAME.TXT", StringComparison.InvariantCultureIgnoreCase)) &&
                    archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_BAIRRO.TXT", StringComparison.InvariantCultureIgnoreCase)) &&
                    archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOCALIDADE.TXT", StringComparison.InvariantCultureIgnoreCase)) &&
                    pesquisarLogradouros(archive)
                    );
        }

        private bool pesquisarLogradouros(ZipArchive archive)
        {           
            foreach(String uf in this.estados)
            {
                if(!archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOGRADOURO_" + uf + ".TXT", StringComparison.InvariantCultureIgnoreCase)))
                {
                    return false;
                }
            }
            return true;
        }

        private void sincronizar(ZipArchive archive)
        {
            List<BairroDto> listaBairros = leBairros(archive);

            List<LocalidadeDto> listaLocalidades = leLocalidades(archive);            

            List<LogradouroDto> listaLogradouros = leLogradouros(archive);
            
         
           
            int i = 0;
        }

        private List<BairroDto> leBairros(ZipArchive archive)
        {
            List<BairroDto> listaBairros;
            if (archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_BAIRRO.TXT")))
            {
                listaBairros = leArquivo<BairroDto>(archive.GetEntry("Delimitado/LOG_BAIRRO.TXT"));
            }
            else
            {
                listaBairros = leArquivo<BairroDto>(archive.GetEntry("Delimitado/LOG_BAIRRO.txt"));
            }

            return listaBairros;
        }

        private List<LocalidadeDto> leLocalidades(ZipArchive archive)
        {
            List<LocalidadeDto> listaLocalidades;
            if (archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOCALIDADE.TXT")))
            {
                listaLocalidades = leArquivo<LocalidadeDto>(archive.GetEntry("Delimitado/LOG_LOCALIDADE.TXT"));
            }
            else
            {
                listaLocalidades = leArquivo<LocalidadeDto>(archive.GetEntry("Delimitado/LOG_LOCALIDADE.txt"));
            }

            return listaLocalidades;
        }

        private List<LogradouroDto> leLogradouros(ZipArchive archive)
        {
            List<LogradouroDto> listaLogradouros = new List<LogradouroDto>();

            foreach(String uf in this.estados)
            {
                if (archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOGRADOURO_" + uf + ".TXT")))
                {
                    listaLogradouros.AddRange(leArquivo<LogradouroDto>(archive.GetEntry("Delimitado/LOG_LOGRADOURO_" + uf + ".TXT")));
                }
                else
                {
                    listaLogradouros.AddRange(leArquivo<LogradouroDto>(archive.GetEntry("Delimitado/LOG_LOGRADOURO_" + uf + ".txt")));
                }

            }           

            return listaLogradouros;
        }



        private List<T> leArquivo <T> (ZipArchiveEntry caminho) where T:BaseDto
        {
            List<T> listaBase = new List<T>();
            try
            {
                using (StreamReader sr = new StreamReader(caminho.Open()))
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
        
        private readonly IArquivoImportacaoRepositorio _arquivoImportacaoRepositorio;
    }
}
