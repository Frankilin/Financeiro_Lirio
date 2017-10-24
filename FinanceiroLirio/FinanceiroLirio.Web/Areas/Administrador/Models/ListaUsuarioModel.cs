using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web
{
    public class ListaUsuarioModel
    {
        public string NomeCompleto { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

        public int GrupoUsuarioSelecionado { get; set; }
        public SelectList GrupoUsuario { get; set; }

        public int IdUsuario { get; set; }

    }
}