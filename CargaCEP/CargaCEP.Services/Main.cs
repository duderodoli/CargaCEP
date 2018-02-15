using CargaCEP.Infra.Util.Constantes;
using CargaCEP.Services.Registry;
using FluentScheduler;
using Serilog;
using System;

namespace CargaCEP.Services
{
    public class Main : FluentScheduler.Registry
    {
        private readonly SchedulerRegistry _registro;

        public Main(SchedulerRegistry registro)
        {
            _registro = registro;

            JobManager.JobException += info =>
            {
                Log.Fatal(info.Exception, "JobManager.JobException");
            };
        }

        public void Start()
        {
            Log.Information($"Iniciando {Constantes.WIN_SERVICE_DISPLAY_NAME} às {DateTime.Now}");
            JobManager.Initialize(_registro);
        }

        public void Stop()
        {
            Log.Information($"Encerrando {Constantes.WIN_SERVICE_DISPLAY_NAME} às {DateTime.Now}");
            JobManager.Stop();
        }
    }
}
