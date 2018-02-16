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
            this.complemento = parametros[6];
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
        public string complemento { get; set; }
        public string cep { get; set; }
        public string tipoLogradouro { get; set; }
        public char indicadorUtilizacaoTipoLogradouro { get; set; }
        public string nomeAbreviado { get; set; }
        
    }
}
