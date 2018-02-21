using CargaCEP.Dominio.Entidade;
using CargaCEP.Dominio.Nucleo;
using CargaCEP.Dominio.Repositorio;
using CargaCEP.Repositorio.Base;
using Dapper;
using System.Data;

namespace CargaCEP.Repositorio
{
    class RegistroLogRepositorio : RepositorioBase, IRegistroLogRepositorio
    {
        private static string GRAVAR_LOG;

        private static IDbConnection conexao;

        public RegistroLogRepositorio(IConexaoBase conexaoBase)
        {
            conexao = conexaoBase.AbrirConexao();
        }

        public void gravarLog(RegistroLog registroLog)
        {
            conexao.Execute(GRAVAR_LOG, registroLog);
        }

    }
}
