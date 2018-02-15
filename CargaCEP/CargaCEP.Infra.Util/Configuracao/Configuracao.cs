using System.Configuration;

namespace CargaCEP.Infra.Util.Configuracao
{
    public static class Configuracao
    {
        public static int FREQUENCIA_DE_EXECUCAO
        {
            get
            {
                string frequenciaDeExecucao = ConfigurationManager.AppSettings["FREQUENCIA_DE_EXECUCAO"];
                return string.IsNullOrEmpty(frequenciaDeExecucao) ? 10 : int.Parse(frequenciaDeExecucao);
            }
        }
    }
}
