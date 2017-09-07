using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Entidades
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nome { get; set; }

        public virtual List<Cidade> Cidade { get; set; }
    }
}
