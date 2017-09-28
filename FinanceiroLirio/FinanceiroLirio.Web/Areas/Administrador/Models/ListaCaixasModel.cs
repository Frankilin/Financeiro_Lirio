using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinanceiroLirio.Entidades;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class ListaCaixasModel
    {
        public int CongregacaoSelecionada { get; set; }
        public string Descricao { get; set; }
        public decimal SaldoInicial { get; set; }
    }

}
