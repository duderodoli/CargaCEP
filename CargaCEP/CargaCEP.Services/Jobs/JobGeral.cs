using CargaCEP.Dominio.Processo;
using CargaCEP.Infra.Util.Constantes;
using Serilog;
using System.Configuration;

namespace CargaCEP.Services.Jobs
{
    public class JobGeral : IWorker
    {
        private readonly ICargaCepProcesso _cargaCepProcesso;

        public JobGeral(ICargaCepProcesso cargaCepProcesso)
        {
            _cargaCepProcesso = cargaCepProcesso;
        }

        public void Execute()
        {
            Log.Information(string.Format("Iniciar Sincronização - Versão: {0}", ConfigurationManager.AppSettings["VERSAO"]));
            _cargaCepProcesso.ExecutarSincronizacaoCep();
        }

        public string GetWorkerName()
        {
            return Constantes.NOME_JOB_GERAL;
        }
    }
}
