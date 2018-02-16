using CargaCEP.Dominio.Processo;
using CargaCEP.Dominio.Repositorio;
using System;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Aplicacao.Processo
{
    public class CargaCepProcesso : ICargaCepProcesso
    {
        public void ExecutarSincronizacaoCep(string filePath)
        {            
            ZipArchive archive = ZipFile.OpenRead(filePath);
            bool result = validarCarga(archive);            
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
            List<string> estados = new List<string>() {
                                                        "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA",
                                                        "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"
                                                      };
            
            foreach(String estado in estados)
            {
                if(!archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_LOGRADOURO_" + estado + ".TXT", StringComparison.InvariantCultureIgnoreCase)))
                {
                    return false;
                }
            }
            return true;
        }

        private readonly IArquivoImportacaoRepositorio _arquivoImportacaoRepositorio;
    }
}
