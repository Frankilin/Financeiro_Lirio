using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class ListaCongregacaoModel
    {
        public int IdCongregacao { get; set; }
        public string Apelido { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}