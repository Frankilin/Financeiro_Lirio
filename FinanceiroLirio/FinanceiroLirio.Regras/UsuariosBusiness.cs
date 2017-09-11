using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.Persistence;
using FinanceiroLirio.Util;

namespace FinanceiroLirio.Regras
{
    public class UsuariosBusiness
    {
        public Usuario RealizarLogin(string login, string senha)
        {
            Usuario u = null;
            try
            {
                if (login == null || senha == null)
                {
                    throw new Exception("Login e/ou senha inválidos");
                }

                UsuarioRepository ur = new UsuarioRepository();

                u = ur.FindByLoginSenha(login, Criptografia.CriptografarMD5(senha));

                if(u == null)
                {
                    throw new Exception("Login e/ou senha incorretos. Tente novamente.");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return u;
        }
    }
}
