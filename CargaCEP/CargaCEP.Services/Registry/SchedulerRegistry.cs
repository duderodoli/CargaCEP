using CargaCEP.Infra.Util.Configuracao;
using CargaCEP.Infra.Util.Constantes;
using CargaCEP.Services.Jobs;
using Serilog;
using System;
using System.Linq;

namespace CargaCEP.Services.Registry
{
    public class SchedulerRegistry : FluentScheduler.Registry
    {
        public SchedulerRegistry(params IWorker[] workers)
        {
            var jobGeral =
                workers.FirstOrDefault(w => w.GetWorkerName().Equals(Constantes.NOME_JOB_GERAL));

            Schedule(() =>
            {
                try
                {
                    jobGeral?.Execute();
                }
                catch (Exception e)
                {
                    Log.Fatal(e, "jobGeral");
                }
            }).NonReentrant().ToRunNow().AndEvery(Configuracao.FREQUENCIA_DE_EXECUCAO).Seconds();
        }

    }
}
