using System.Collections.Generic;

namespace FinanceiroLirio.Entidades
{
    public class Cidade
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public int IdEstado { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual List<Endereco> Endereco { get; set; }
    }
}
