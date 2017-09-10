using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Entidades
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public int IdCidade { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual List<Congregacao> Congregacao { get; set; }

    }
}
