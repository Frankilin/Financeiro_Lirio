using System.Collections.Generic;

namespace FinanceiroLirio.Entidades
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nome { get; set; }

        public virtual List<Cidade> Cidade { get; set; }
    }
}
