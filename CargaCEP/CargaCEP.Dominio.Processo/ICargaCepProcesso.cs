using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.Processo
{
    public interface ICargaCepProcesso
    {
        void ExecutarSincronizacaoCep(string caminhoArquivo, List<String> mensagemErro, BackgroundWorker backGroundWorker);
    }
}
