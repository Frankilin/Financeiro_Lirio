using FinanceiroLirio.Entidades;
using FinanceiroLirio.Regras;
using FinanceiroLirio.Web.Areas.Administrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : Controller
    {
        // GET: Administrador/Usuario
        
        public ActionResult Novo()
        {
            try
            {
                GrupoUsuarioBusiness gub = new GrupoUsuarioBusiness();

                var model = new CadastroUsuarioModel();

                model.GrupoUsuario = gub.ListaGrupoUsuarioDropdownList();
                ViewBag.ListaGrupousuario = gub.ListaGrupoUsuarioDropdownList();

                ViewBag.Title = "Cadastrar usuário";

                return View(model);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("Novo", "Home");
            }
        }

        [HttpPost]
        public ActionResult Novo(CadastroUsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario user = new Usuario();
                    GrupoUsuario gu = new GrupoUsuario();

                    user.NomeCompleto = model.NomeCompleto;
                    user.Login = model.Login;
                    user.Senha = model.Senha;
                    user.Email = model.Email;
                    user.IdGrupoUsuario = model.GrupoUsuarioSelecionado;

                    UsuarioBusiness ub = new UsuarioBusiness();

                    user = ub.NovoUsuario(user);

                    user = ub.RealizarLogin(user.Login, user.Senha);

                    TempData["Mensagem"] = "Usuário cadastrado com sucesso.";
                    TempData["Resposta"] = "Sucesso";
                }
            }
            catch (Exception e)
            {

                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
            }
            return View(model);
        }

        public ActionResult Lista()
        {
            List<ListaUsuarioModel> lista = new List<ListaUsuarioModel>();

            try
            {
                UsuarioBusiness ub = new UsuarioBusiness();

                List<Usuario> u = ub.TodosUsuarios();

                foreach (Usuario user in u)
                {
                    ListaUsuarioModel temp = new ListaUsuarioModel();

                    temp.NomeCompleto = user.NomeCompleto;
                    temp.Login        = user.Login;
                    temp.Senha        = user.Senha;
                    temp.Email        = user.Email;
                    
                    lista.Add(temp);
                }
                return View(lista);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("Novo", "Home");
            }
        }


    }
}