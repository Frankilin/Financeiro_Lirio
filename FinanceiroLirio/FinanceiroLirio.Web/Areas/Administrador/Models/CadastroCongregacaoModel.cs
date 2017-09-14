using FinanceiroLirio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Models
{
    public class CadastroCongregacaoModel
    {
        [Required(ErrorMessage = "Informe a descrição da congregação")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o apelido da congregação.")]
        public string Apelido { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade da congregação.")]
        [Display(Name = "Cidade")]
        public int CidadeSelecionada { get; set; }
        public SelectList Cidade { get; set; }

    }
}