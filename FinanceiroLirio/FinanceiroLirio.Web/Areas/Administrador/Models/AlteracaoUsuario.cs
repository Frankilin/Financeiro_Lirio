using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class AlteracaoUsuario
    {
        [HiddenInput(DisplayValue = false)]
        public int IdUsuario { get; set; }

        [Display(Name ="Nome do Usuário")]
        [Required(ErrorMessage ="O nome do usuário é obrigatório")]
        public string Nome { get; set; }

        [Display(Name ="Senha")]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
      
        [Required(ErrorMessage = "Inclua o grupo do usuário")]
        [Display(Name = "Grupo do Usuário")]

        public int GrupoUsuarioSelecionado { get; set; }
        public SelectList GrupoUsuario { get; set; }
    }
}