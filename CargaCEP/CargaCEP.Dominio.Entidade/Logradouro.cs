using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.Entidade
{
    public class Logradouro
    {
        public int LOG_NU { get; set; }
        public string UFE_SG { get; set; }        
        public int LOC_NU { get; set; }
        public int BAI_NU_INI { get; set; }
        public int BAI_NU_FIM { get; set; }
        public string LOG_NO { get; set; }
        public string LOG_COMPLEMENTO { get; set; }
        public string CEP { get; set; }
        public string TLO_TX { get; set; }
        public char LOG_STA_TLO { get; set; }
        public string LOG_NO_ABREV { get; set; }        
    }
}
