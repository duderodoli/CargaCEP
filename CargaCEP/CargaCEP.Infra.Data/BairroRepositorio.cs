using CargaCEP.Dominio.Nucleo;
using CargaCEP.Dominio.Repositorio;
using CargaCEP.Repositorio.Base;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace CargaCEP.Repositorio
{
    public class BairroRepositorio : RepositorioBase, IBairroRepositorio
    {
        private static string INSERIR_BAIRRO = @"
            INSERT INTO dbo.LOG_BAIRRO (
                BAI_NU,
                UFE_SG,
                LOC_NU,
                BAI_NO,
                BAI_NO_ABREV
            )
            VALUES (
                @bai_nu,
                @ufe_sg,
                @loc_nu,
                @bai_no,
                @bai_no_abrev
            )
        ";

        private static string DELETAR_BAIRROS = "TRUNCATE TABLE LOG_BAIRRO";

        private static IDbConnection conexao;
        
        public BairroRepositorio(IConexaoBase conexaoBase)
        {
            conexao = conexaoBase.AbrirConexao();
        }

        public void InserirBairros(List<Dominio.Entidade.Bairro> listaBairros)
        {
            DeletarBairros();
            conexao.Execute(INSERIR_BAIRRO, listaBairros);
        }

        private void DeletarBairros()
        {
            conexao.Execute(DELETAR_BAIRROS);
        }

        
    }
}
