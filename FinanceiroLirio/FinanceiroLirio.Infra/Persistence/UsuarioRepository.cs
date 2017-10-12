using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.DataSource;
using FinanceiroLirio.Infra.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FinanceiroLirio.Infra.Persistence
{
    public class UsuarioRepository : OperacoesGenericas<Usuario>
    {
        public Usuario FindByLoginSenha(string login, string senha)
        {
            using (Conexao con = new Conexao())
            {
                return con.Usuario
                    .Include(u => u.GrupoUsuario)
                    .SingleOrDefault(u => u.Login.Equals(login) && u.Senha.Equals(senha));
            }
        }
    }
}
