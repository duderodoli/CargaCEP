using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.Repositorio
{
    public interface ILocalidadeRepositorio
    {
        void InserirLocalidades(List<Dominio.Entidade.Localidade> listaLocalidades);
    }
}
