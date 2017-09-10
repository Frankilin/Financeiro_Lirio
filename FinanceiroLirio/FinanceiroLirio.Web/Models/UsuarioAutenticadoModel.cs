using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceiroLirio.Web.Models
{
    public class UsuarioAutenticadoModel
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Login { get; set; }
        public string GrupoUsuario { get; set; }
    }
}