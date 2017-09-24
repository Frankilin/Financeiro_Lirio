using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class CadastroCaixaModel
    {
        [Required(ErrorMessage = "Informe a descrição da Caixa")]
        public string Descricao { get; set; }

        [Display(Name = "Saldo Inicial")]
        public decimal SaldoInicial { get; set; }

        [Required(ErrorMessage = "Informe a congregação do caixa.")]
        [Display(Name = "Congregação")]
        public int CongregacaoSelecionada { get; set; }
        public SelectList Congregacao { get; set; }


    }
}