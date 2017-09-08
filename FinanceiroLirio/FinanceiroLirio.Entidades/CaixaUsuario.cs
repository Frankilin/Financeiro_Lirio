using System;
using System.Collections.Generic;

namespace FinanceiroLirio.Entidades
{
    public class CaixaUsuario
    {
        public int IdCaixaUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdCaixa { get; set; }
        public DateTime DataInclusao { get; set; }

        public virtual List<Caixa> Caixa { get; set; }
        public virtual List<Usuario> Usuario { get; set; }

    }
}
