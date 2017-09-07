using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Entidades
{
    public class Congregacao
    {
        public int IdCongregacao { get; set; }
        public string Descricao { get; set; }
        public string Apelido { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int IdEndereco { get; set; }

        public virtual List<Caixa> Caixa { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
