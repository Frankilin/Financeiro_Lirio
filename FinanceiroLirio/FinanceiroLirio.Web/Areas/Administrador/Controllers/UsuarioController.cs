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
    public class UsuarioController : Controller
    {
        // GET: Administrador/Usuario
        [Authorize(Roles = "Administrador")]
        public ActionResult Nova()
        {
            try
            {
                var model = new CadastroUsuarioModel();

                ViewBag.Title = "Cadastrar usuário";

                return View(model);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("Nova", "Home");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Nova(CadastroUsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario user = new Usuario();

                    user.NomeCompleto = model.NomeCompleto;
                    user.Login = model.Login;
                    user.Senha = model.Senha;
                    user.Email = model.Email;

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

        [Authorize(Roles = "Administrador")]
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
                return RedirectToAction("Nova", "Home");
            }
        }
    }
}