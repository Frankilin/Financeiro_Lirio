using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class DeleteCaixaModel
    {

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Código")]
        public int IdCaixa { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

    }
}