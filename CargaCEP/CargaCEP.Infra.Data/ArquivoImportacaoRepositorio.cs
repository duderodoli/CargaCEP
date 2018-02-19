using CargaCEP.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Repositorio
{
    public class ArquivoImportacaoRepositorio : IArquivoImportacaoRepositorio
    {

        private static string INSERIR_BAIRRO = "";
        private static string INSERIR_LOCALIDADE = "";
        private static string INSERIR_LOGRADOURO = "";
        



        public void inserirDados(
                                    List<Dominio.Entidade.Bairro> listaBairros,
                                    List<Dominio.Entidade.Localidade> listaLocalidades,
                                    List<Dominio.Entidade.Logradouro> listaLogradouros
                                )
        {
            inserirDadosBairro(listaBairros);
            inserirDadosLocalidade(listaLocalidades);
            inserirDadosLogradouro(listaLogradouros);
        }

        private void inserirDadosBairro(List<Dominio.Entidade.Bairro> listaBairros)
        {
            
        }
        private void inserirDadosLocalidade(List<Dominio.Entidade.Localidade> listaLocalidades)
        {

        }
        private void inserirDadosLogradouro(List<Dominio.Entidade.Logradouro> listaLogradouros)
        {

        }

    }
}
