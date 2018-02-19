using CargaCEP.Dominio.Nucleo;
using CargaCEP.Dominio.Repositorio;
using CargaCEP.Repositorio.Base;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace CargaCEP.Repositorio
{
    public class LocalidadeRepositorio : RepositorioBase, ILocalidadeRepositorio
    {
        private static string INSERIR_LOCALIDADE = @"
            INSERT INTO dbo.LOG_LOCALIDADE (
                LOG_NU,
                UFE_SG,
                LOC_NO,
                CEP,
                LOC_IN_SIT,
                LOC_IN_TIPO_LOC,
                LOC_NU_SUB,
                LOC_NO_ABREV,
                MUN_NU
            )
            VALUES (
                @log_nu,
                @ufe_sg,
                @loc_no,
                @cep,
                @loc_in_sit,
                @loc_in_tipo_loc,
                @loc_nu_sub,
                @loc_no_abrev,
                @mun_nu
            )
        ";

        private static string DELETAR_LOCALIDADES = "TRUNCATE TABLE LOG_LOCALIDADE";

        private static IDbConnection conexao;

        public LocalidadeRepositorio(IConexaoBase conexaoBase)
        {
            conexao = conexaoBase.AbrirConexao();
        }

        public void InserirLocalidades(List<Dominio.Entidade.Localidade> listaLocalidades)
        {
            DeletarLocalidades();
            conexao.Execute(INSERIR_LOCALIDADE, listaLocalidades);
        }

        private void DeletarLocalidades()
        {
            conexao.Execute(DELETAR_LOCALIDADES);
        }
    }
}
