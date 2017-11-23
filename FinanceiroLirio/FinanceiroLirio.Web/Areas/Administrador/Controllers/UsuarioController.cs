using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.DataSource;
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
                //ViewBag.ListaGrupousuario = gub.ListaGrupoUsuarioDropdownList();

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
                    user.DataCadastro = DateTime.Now;
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
            //return view(model);
            return RedirectToAction("Novo");
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
                    temp.GrupoUsuarioSelecionado = user.IdGrupoUsuario;
                    temp.IdUsuario = user.IdUsuario;
                    
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

        public ActionResult Alteracao(int id)
        {
            try
            {
                UsuarioBusiness ub = new UsuarioBusiness();
                GrupoUsuarioBusiness gb = new GrupoUsuarioBusiness();
                AlteracaoUsuario model = new AlteracaoUsuario();
                Usuario u = ub.FindById(id);

                model.GrupoUsuario              = gb.ListaGrupoUsuarioDropdownList();
                model.IdUsuario                 = u.IdUsuario;
                model.GrupoUsuarioSelecionado   = u.IdGrupoUsuario;
                model.Nome                      = u.NomeCompleto;
                model.Senha                     = u.Senha;

                return View(model);
            }
            catch (Exception e)
            {

                ViewBag.Mensagem = e.Message;
                return RedirectToAction("Lista");
            }

        }

        [HttpPost]
        public ActionResult Alteracao(AlteracaoUsuario model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioBusiness ub = new UsuarioBusiness();
                    GrupoUsuarioBusiness gb = new GrupoUsuarioBusiness();
                    Usuario user = ub.FindById(model.IdUsuario);
                    Usuario temp = new Usuario();

                    temp.IdUsuario          = model.IdUsuario;
                    temp.Login              = user.Login;
                    temp.NomeCompleto       = model.Nome;
                    temp.Senha              = model.Senha;
                    temp.Email              = user.Email;
                    temp.DataCadastro       = user.DataCadastro;
                    temp.IdGrupoUsuario     = model.GrupoUsuarioSelecionado;
                    model.GrupoUsuario      = gb.ListaGrupoUsuarioDropdownList();

                    ub.Alteracao(temp);

                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                //return RedirectToAction("Lista");
            }
            //return View();
            return RedirectToAction("Lista");
        }
    }
}