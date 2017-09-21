using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    }
}