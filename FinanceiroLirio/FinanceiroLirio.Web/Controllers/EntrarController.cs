using FinanceiroLirio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceiroLirio.Entidades;
using System.Web.Security;
using Newtonsoft.Json;
using FinanceiroLirio.Regras;

namespace FinanceiroLirio.Web.Controllers
{
    public class EntrarController : Controller
    {
        public object Usuario { get; private set; }

        // GET: Entrar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioBusiness ur = new UsuarioBusiness();

                    Usuario u = ur.RealizarLogin(model.Login, model.Senha);

                    if(u == null)
                    {
                        throw new Exception("Usuário e/ou senha incorretos.");
                    }

                    UsuarioAutenticadoModel aut = new UsuarioAutenticadoModel();

                    aut.NomeCompleto = u.NomeCompleto;
                    aut.Login = u.Login;
                    aut.IdUsuario = u.IdUsuario;
                    aut.GrupoUsuario = u.GrupoUsuario.Descricao;

                    FormsAuthenticationTicket ticket = 
                        new FormsAuthenticationTicket(JsonConvert.SerializeObject(aut), false, 80);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(cookie);

                    if(aut.GrupoUsuario == "Administrador")
                    {
                        return RedirectToAction("Nova", "Home", new { area = "Administrador" });//acesso master
                    }else if(aut.GrupoUsuario == "Operador")
                    {
                        return RedirectToAction("Nova", "Painel", new { area = "PainelAdministrativo" });//operadores comuns
                    }
                }
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View(model);
        }

        public ActionResult Sair()
        {
            try
            {
                FormsAuthentication.SignOut();
            }
            catch(Exception e)
            {
                ViewBag.Mensagem(e.Message);
            }
            return Redirect("Nova");
        }
    }
}