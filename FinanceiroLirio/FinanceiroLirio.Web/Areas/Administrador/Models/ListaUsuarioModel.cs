using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceiroLirio.Web
{
    public class ListaUsuarioModel
    {
        public string NomeCompleto { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}