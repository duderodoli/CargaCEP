using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.DTO
{
    public class LocalidadeDto : BaseDto
    {
        public LocalidadeDto(String[] parametros)
        {
            this.chave = Int32.Parse(parametros[0]);
            this.uf = parametros[1];
            this.nomeLocalidade = parametros[2];
            this.cep = parametros[3];
            this.situacaoLocalidade = Int32.TryParse(parametros[4], out int outInt) ? outInt : -1;
            this.tipoLocalidade = parametros[5][0];
            this.chaveSubordinacao = Int32.TryParse(parametros[6], out outInt) ? outInt : -1;
            this.nomeLocalidadeAbreviado = parametros[7];
            this.codigoMunicipio = parametros[8];

        }

        public int chave { get; set; }
        public string uf { get; set; }
        public string nomeLocalidade { get; set; }
        public string cep { get; set; }
        public int situacaoLocalidade { get; set; }
        public char tipoLocalidade { get; set; }
        public int chaveSubordinacao { get; set; }
        public string nomeLocalidadeAbreviado { get; set; }
        public string codigoMunicipio { get; set; }
        
    }
}
