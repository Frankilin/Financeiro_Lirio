using System;
using System.Collections.Generic;

namespace FinanceiroLirio.Entidades
{
    public class Caixa
    {
        public int IdCaixa { get; set; }
        public string Descricao { get; set; }
        public decimal SaldoInicial { get; set; }
        public int IdCongregacao { get; set; }
        public DateTime DataInclusao { get; set; }

        public virtual Congregacao Congregacao { get; set; }
        public virtual List<CaixaUsuario> CaixaUsuario { get; set; }

    }
}
