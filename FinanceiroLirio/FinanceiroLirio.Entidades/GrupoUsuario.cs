using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Entidades
{
    public class GrupoUsuario
    {
        public int IdGrupoUsuario { get; set; }
        public string Descricao { get; set; }

        public virtual List<Usuario>  Usuario { get; set; }
    }
}
