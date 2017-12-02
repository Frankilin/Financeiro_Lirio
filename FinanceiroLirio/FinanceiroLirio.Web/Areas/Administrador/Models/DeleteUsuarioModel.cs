using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class DeleteUsuarioModel
    {
        //[HiddenInput(DisplayValue = false)]
        [Display(Name = "Código")]
        public int IdUsuario { get; set; }

        [Display(Name = "Nome do Usuário")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}