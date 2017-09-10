using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.PainelAdministrativo.Controllers
{
    [Authorize(Roles = "Operador")]
    public class PainelController : Controller
    {
        // GET: PainelAdministrativo/Painel
        public ActionResult Index()
        {
            return View();
        }
    }
}