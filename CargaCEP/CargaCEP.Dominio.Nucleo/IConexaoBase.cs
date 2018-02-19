using System.Data;

namespace CargaCEP.Dominio.Nucleo
{
    public interface IConexaoBase
    {
        IDbConnection AbrirConexao();
        void FecharConexao();
    }
}
