using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HomeController : Controller
    {
        // GET: Administrador/Home
        public ActionResult Index()
        {
            ViewBag.Titulo = "Início";
            return View();
        }
    }
}