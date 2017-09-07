using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Boolean Ativo { get; set; }
        //public int IdCargo { get; set; }
        public int IdGrupoUsuario { get; set; }
        //public int IdSetor { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual GrupoUsuario GrupoUsuario { get; set; }
        //public virtual List<CaixaUsuario> CaixaUsuario { get; set; }
    }
}
