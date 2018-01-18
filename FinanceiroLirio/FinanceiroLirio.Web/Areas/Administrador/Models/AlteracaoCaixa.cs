using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class AlteracaoCaixa
    {

        [HiddenInput(DisplayValue = false)]
        public int IdCaixa { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição da caixa é obrigatória.")]
        public string Descricao { get; set; }
    
        [Display(Name = "Saldo Inicial")]
        [Required(ErrorMessage = "Saldo inicial é obrigatório.")]
        public decimal SaldoInicial { get; set; }

        [Display(Name = "Congregação")]
        [Required(ErrorMessage = "Favor selecionar uma congregação.")]
        public int CongregacaoSelecionada { get; set; }

        public SelectList Congregacaos { get; set; }
    }
}