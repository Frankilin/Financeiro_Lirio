﻿using FinanceiroLirio.Entidades;
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

                u.IdUsuario = 10;
                u.Ativo = true;
                u.DataCadastro = DateTime.Now;
                u.IdGrupoUsuario = 3;

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
                    throw new Exception("Nenhuma usuário encontrada.");
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
