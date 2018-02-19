using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaCEP.Repositorio.Base
{
    public abstract class RepositorioBase
    {
        protected IDbTransaction Transacao { get; set; }
        protected IDbConnection Conexao { get; set; }
    }
}
