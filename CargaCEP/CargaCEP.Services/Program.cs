using CargaCEP.Dominio.Processo;
using CargaCEP.Infra.Util.Constantes;
using CargaCEP.IoC;
using CargaCEP.Services.Jobs;
using CargaCEP.Services.Registry;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using Topshelf;

namespace CargaCEP.Services
{
    internal class Program
    {
        protected Program()
        {

        }

        public static void Main()
        {
            InicializarConfiguracoesLog();

            IoCIniciar.Iniciar();

            var cargaCepProcesso = IoCIniciar.ObterInstancia<ICargaCepProcesso>();

            var schedulerRegistry = new SchedulerRegistry(
                new JobGeral(cargaCepProcesso)
            );

            HostFactory.Run(x =>
            {
                x.Service<Main>(s =>
                {
                    s.ConstructUsing(name => new Main(schedulerRegistry));
                    s.WhenStarted(m => m.Start());
                    s.WhenStopped(m => m.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription(Constantes.WIN_SERVICE_DESCRICAO);
                x.SetDisplayName(Constantes.WIN_SERVICE_DISPLAY_NAME);
                x.SetServiceName(Constantes.WIN_SERVICE_SERVICE_NAME);
                x.StartAutomatically();

                x.EnableServiceRecovery(r =>
                {
                    r.RestartService(1);
                });

                x.OnException(ex =>
                {

                });
            });
        }

        private static void InicializarConfiguracoesLog()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["log"].ConnectionString;
            var tableName = "IntegracaoContratoLog";
            var columnOptions = new ColumnOptions()
            {
                AdditionalDataColumns = new Collection<DataColumn>
                    {
                        new DataColumn {DataType = typeof(string), ColumnName = "Integracao"},
                        new DataColumn {DataType = typeof(string), ColumnName = "Entidade" },
                        new DataColumn {DataType = typeof(int), ColumnName = "EntidadeId" }
                    }
            };

            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(connectionString, tableName, columnOptions: columnOptions)
                .CreateLogger();
        }
    }
}
