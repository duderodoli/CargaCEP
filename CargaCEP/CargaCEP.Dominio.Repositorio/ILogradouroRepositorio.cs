using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.Repositorio
{
    public interface ILogradouroRepositorio
    {
        void InserirLogradouros(List<Dominio.Entidade.Logradouro> listaLogradouros);
    }
}
