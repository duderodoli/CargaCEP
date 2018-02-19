using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.Processo
{
    public interface ICargaCepProcesso
    {
        String ExecutarSincronizacaoCep(string caminhoArquivo);
    }
}
