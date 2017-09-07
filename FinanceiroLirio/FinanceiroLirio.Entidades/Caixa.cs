using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Entidades
{
    public class Caixa
    {
        public int IdCaixa { get; set; }
        public string Descricao { get; set; }
        public decimal SaldoInicial { get; set; }
        public int IdCongregacao { get; set; }
        public DateTime DataInclusao { get; set; }
        
    }
}
