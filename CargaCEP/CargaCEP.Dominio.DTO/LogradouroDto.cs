using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.DTO
{
    public class LogradouroDto : BaseDto
    {

        public LogradouroDto(String[] parametros)
        {
            this.chave = Int32.TryParse(parametros[0], out int outInt) ? outInt : -1;
            this.uf = parametros[1];
            this.chaveLocalidade = Int32.TryParse(parametros[2], out outInt) ? outInt : -1;
            this.chaveBairroInicial = Int32.TryParse(parametros[3], out outInt) ? outInt : -1;
            this.chaveBairroFinal = Int32.TryParse(parametros[4], out outInt) ? outInt : -1;
            this.nomeLogradouro = parametros[5];
            this.complementoLogradouro = parametros[6];
            this.cep = parametros[7];
            this.tipoLogradouro = parametros[8];
            this.indicadorUtilizacaoTipoLogradouro = parametros[9][0];
            this.nomeAbreviado = parametros[10];

        }

        public int chave { get; set; }
        public string uf { get; set; }
        public int chaveLocalidade { get; set; }
        public int chaveBairroInicial { get; set; }
        public int chaveBairroFinal { get; set; }
        public string nomeLogradouro { get; set; }
        public string complementoLogradouro { get; set; }
        public string cep { get; set; }
        public string tipoLogradouro { get; set; }
        public char indicadorUtilizacaoTipoLogradouro { get; set; }
        public string nomeAbreviado { get; set; }


        public Dominio.Entidade.Logradouro criarEntidade()
        {
            var entidade = new Dominio.Entidade.Logradouro();
            entidade.LOG_NU = this.chave;
            entidade.UFE_SG = this.uf;
            entidade.LOC_NU = this.chaveLocalidade;
            entidade.BAI_NU_INI = this.chaveBairroInicial;
            entidade.BAI_NU_FIM = this.chaveBairroFinal;
            entidade.LOG_NO = this.nomeLogradouro;
            entidade.LOG_COMPLEMENTO = this.complementoLogradouro;
            entidade.CEP = this.cep;
            entidade.TLO_TX = this.tipoLogradouro;
            entidade.LOG_STA_TLO = this.indicadorUtilizacaoTipoLogradouro;
            entidade.LOG_NO_ABREV = this.nomeAbreviado;

            return entidade;

        }

    }
}
