using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Dominio.Entidade
{
    public class Localidade
    {
        public int LOG_NU { get; set; }
        public string UFE_SG { get; set; }        
        public string LOC_NO { get; set; }
        public string CEP { get; set; }
        public int LOC_IN_SIT { get; set; }
        public char LOC_IN_TIPO_LOC { get; set; }
        public int LOC_NU_SUB { get; set; }        
        public string LOC_NO_ABREV { get; set; }
        public string MUN_NU { get; set; }
    }
}
