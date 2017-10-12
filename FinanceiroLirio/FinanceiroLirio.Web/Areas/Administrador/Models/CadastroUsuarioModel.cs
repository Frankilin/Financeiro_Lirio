using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class CadastroUsuarioModel
    {
        [Required(ErrorMessage = "Informe o nome completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Inclua o grupo do usuário")]
        [Display(Name = "Grupo do Usuário")]
        public int GrupoUsuarioSelecionado { get; set; }
        public SelectList GrupoUsuario { get; set; }
    }
}