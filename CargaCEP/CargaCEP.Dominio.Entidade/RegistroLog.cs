using System;

namespace CargaCEP.Dominio.Entidade
{
    public class RegistroLog
    {
        public int userId { get; set; }
        public DateTime dataHora { get; set; }
        public string maquina { get; set; }
        public string cabecalho { get; set; }
        public string logExecucao { get; set; }

        public RegistroLog(int userId, DateTime dataHora, string maquina, string cabecalho, string logExecucao)
        {
            this.userId = userId;
            this.dataHora = dataHora;
            this.maquina = maquina;
            this.cabecalho = cabecalho;
            this.logExecucao = logExecucao;
        }
    }
}
