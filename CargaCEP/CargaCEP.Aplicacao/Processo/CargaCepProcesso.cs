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
            //throw new NotImplementedException();
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
            return (archive.Entries.Count(a => a.FullName.Contains("Delimitado/LOG_LOGRADOURO")) == 27);
        }

        private readonly IArquivoImportacaoRepositorio _arquivoImportacaoRepositorio;
    }
}
