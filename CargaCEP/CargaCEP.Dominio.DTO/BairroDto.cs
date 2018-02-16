using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.DTO
{
    public class BairroDto : BaseDto
    {
        public BairroDto(String[] parametros)
        {
            this.chave = Int32.TryParse(parametros[0], out int outInt) ? outInt : -1;
            this.uf = parametros[1];
            this.chaveLocalidade = Int32.TryParse(parametros[2], out outInt) ? outInt : -1;
            this.nome = parametros[3];
            this.nomeAbreviado = parametros[4];
        }

        public int chave { get; set; }
        public string uf { get; set; }
        public int chaveLocalidade { get; set; }
        public string nome { get; set; }
        public string nomeAbreviado { get; set; }       
        
    }
}
