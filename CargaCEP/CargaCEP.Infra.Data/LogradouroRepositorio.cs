using CargaCEP.Dominio.Nucleo;
using CargaCEP.Dominio.Repositorio;
using CargaCEP.Repositorio.Base;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace CargaCEP.Repositorio
{
    public class LogradouroRepositorio : RepositorioBase, ILogradouroRepositorio
    {
        private static string INSERIR_LOGRADOURO = @"
        INSERT INTO dbo.LOG_LOGRADOURO (
            LOG_NU,
            UFE_SG,
            LOC_NU,
            BAI_NU_INI,
            BAI_NU_FIM,
            LOG_NO,
            LOG_COMPLEMENTO,
            CEP,
            TLO_TX,
            LOG_STA_TLO,
            LOG_NO_ABREV
        )
        VALUES (
            @log_nu,
            @ufe_sg, 
            @loc_nu, 
            @bai_nu_ini,
            @bai_nu_fim, 
            @log_no, 
            @log_complemento, 
            @cep, 
            @tlo_tx, 
            @log_sta_tlo, 
            @log_no_abrev
        )
        ";

        private static string DELETAR_LOGRADOUROS = "TRUNCATE TABLE LOG_LOGRADOURO";

        private static IDbConnection conexao;

        public LogradouroRepositorio(IConexaoBase conexaoBase)
        {
            conexao = conexaoBase.AbrirConexao();
        }

        public void InserirLogradouros(List<Dominio.Entidade.Logradouro> listaLogradouros)
        {
            DeletarLogradouros();
            conexao.Execute(INSERIR_LOGRADOURO, listaLogradouros);
        }

        private void DeletarLogradouros()
        {
            conexao.Execute(DELETAR_LOGRADOUROS);
        }

    }
}
