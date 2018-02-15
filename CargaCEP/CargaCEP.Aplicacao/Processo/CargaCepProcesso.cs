using CargaCEP.Dominio.Processo;
using CargaCEP.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Aplicacao.Processo
{
    public class CargaCepProcesso : ICargaCepProcesso
    {
        public void ExecutarSincronizacaoCep()
        {
            throw new NotImplementedException();
        }

        public CargaCepProcesso(IArquivoImportacaoRepositorio arquivoImportacaoRepositorio)
        {
            _arquivoImportacaoRepositorio = arquivoImportacaoRepositorio;
        }

        private readonly IArquivoImportacaoRepositorio _arquivoImportacaoRepositorio;
    }
}
