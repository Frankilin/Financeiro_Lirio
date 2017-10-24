using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FinanceiroLirio.Util;

namespace FinanceiroLirio.Regras
{
    public class UsuarioBusiness
    {

        public Usuario NovoUsuario(Usuario u)
        {
            try
            {
                if (u.NomeCompleto == null)
                {
                    throw new Exception("Informe o nome do usuário.");
                }

                if (u.Login == null)
                {
                    throw new Exception("Informe o Login.");
                }

                u.Ativo = true;
                u.DataCadastro = DateTime.Now;
                u.IdGrupoUsuario = 3;
                u.Senha = Criptografia.CriptografarMD5(u.Senha);

                UsuarioRepository ur = new UsuarioRepository();

                ur.Insert(u);

                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

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

        public List<Usuario> TodosUsuarios()  //função na business que retornará uma listagem de usuarios
        {
            try
            {
                List<Usuario> u = null;

                UsuarioRepository ur = new UsuarioRepository();

                u = ur.All();

                if (u == null)
                {
                    throw new Exception("Nenhum usuário encontrado.");
                }

                return u;
            }
            catch (Exception e)
            {

                throw e;
            }
       }


        public Usuario FindById(int IdUsuario)  
        {
            try
            {
                Usuario u = null;

                UsuarioRepository ur = new UsuarioRepository();

                u = ur.FindById(IdUsuario);

                if (u == null)
                {
                    throw new Exception("Usuário selecionado foi excluido");
                }

                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
