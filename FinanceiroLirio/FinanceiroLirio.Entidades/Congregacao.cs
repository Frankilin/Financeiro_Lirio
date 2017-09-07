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
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public int OperadorInclusao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual List<Caixas> Caixa { get; set; }
    }
}
