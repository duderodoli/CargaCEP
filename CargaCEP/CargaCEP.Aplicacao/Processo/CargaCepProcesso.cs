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
            validarCarga(archive);
            int i = 0;
            //throw new NotImplementedException();
        }

        public CargaCepProcesso(IArquivoImportacaoRepositorio arquivoImportacaoRepositorio)
        {
            _arquivoImportacaoRepositorio = arquivoImportacaoRepositorio;
        }
    

        private bool validarCarga(ZipArchive archive)
        {
            return (
                    archive.Entries.Any(a => a.FullName.Equals("LEIAME.TXT")) &&
                    archive.Entries.Any(a => a.FullName.Equals("Delimitado/LOG_BAIRRO.TXT")) &&
                    archive.Entries.Any(a => a.FullName.Equals("LOG_LOCALIDADE.txt")) &&
                    pesquisarLogradouros(archive)
                    );
        }

        private bool pesquisarLogradouros(ZipArchive archive)
        {
            return (archive.Entries.Count(a => a.FullName.Contains("LOG_LOGRADOURO")) == 27);

        }

        private readonly IArquivoImportacaoRepositorio _arquivoImportacaoRepositorio;
    }
}
