using System.Collections.Generic;

namespace FinanceiroLirio.Entidades
{
    public class GrupoUsuario
    {
        public int IdGrupoUsuario { get; set; }
        public string Descricao { get; set; }

        public virtual List<Usuario>  Usuario { get; set; }
    }
}
