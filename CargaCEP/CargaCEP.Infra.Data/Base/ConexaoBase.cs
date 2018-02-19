using CargaCEP.Dominio.Nucleo;
using Supermix.Infraestrutura.Data.Factories;
using System.Data;

namespace CargaCEP.Repositorio.Base
{
    public class ConexaoBase : IConexaoBase
    {
        public IDbConnection Conexao { get; set; }

        public IDbConnection AbrirConexao()
        {
            Conexao = DbConnectionFactory.Criar(connectionStringName: "Correios");
            return Conexao;
        }

        public void FecharConexao()
        {
            Conexao?.Close();
        }
    }
}
