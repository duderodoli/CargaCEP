using CargaCEP.Dominio.Entidade;
using System.Collections.Generic;

namespace CargaCEP.Dominio.Repositorio
{
    public interface IBairroRepositorio
    {
        void InserirBairros(List<Bairro> listaBairros);
    }
}
