using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.Repositorio
{
    public interface IArquivoImportacaoRepositorio
    {
        void inserirDados(
                            List<Dominio.Entidade.Bairro> listaBairros,
                            List<Dominio.Entidade.Localidade> listaLocalidades,
                            List<Dominio.Entidade.Logradouro> listaLogradouros
                         );
    }
}
