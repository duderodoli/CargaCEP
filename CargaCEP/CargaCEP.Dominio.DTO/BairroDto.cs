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
            chave = Int32.TryParse(parametros[0], out int outInt) ? outInt : -1;
            uf = parametros[1];
            chaveLocalidade = Int32.TryParse(parametros[2], out outInt) ? outInt : -1;
            nome = parametros[3];
            nomeAbreviado = parametros[4];
        }

        public int chave { get; set; }
        public string uf { get; set; }
        public int chaveLocalidade { get; set; }
        public string nome { get; set; }
        public string nomeAbreviado { get; set; }
        
        public Dominio.Entidade.Bairro CriarEntidade()
        {
            var entidade = new Dominio.Entidade.Bairro();
            entidade.BAI_NU = chave;
            entidade.UFE_SG = uf;
            entidade.LOC_NU = chaveLocalidade;
            entidade.BAI_NO = nome;
            entidade.BAI_NO_ABREV = nomeAbreviado;

            return entidade;

        }
    }
}
