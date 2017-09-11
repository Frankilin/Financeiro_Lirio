using FinanceiroLirio.Entidades;
using FinanceiroListio.Infra.Persistence;
using MinhaSerie.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Regras
{
    public class UsuarioBusiness
    {
        public Usuario RealizarLogin(string login, string senha)
        {
            Usuario u = null;
            try
            {
                if(login == null || senha == null)
                {
                    throw new Exception("Login e/ou senha inválidos. Tente novamente.");
                }

                UsuarioRepository ur = new UsuarioRepository();

                u = ur.FindByLoginSenha(login, Criptografia.CriptografarMD5(senha));

            }
            catch(Exception e)
            {
                throw e;
            }
            return u;
        }
    }
}
