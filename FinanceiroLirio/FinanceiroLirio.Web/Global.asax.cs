using FinanceiroLirio.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace FinanceiroLirio.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)

            {

                if (HttpContext.Current.User.Identity.IsAuthenticated)

                {

                    if (HttpContext.Current.User.Identity is FormsIdentity)

                    {

                        FormsIdentity id = (FormsIdentity)HttpContext
                            .Current.User.Identity;

                        FormsAuthenticationTicket ticket = id.Ticket;

                        UsuarioAutenticadoModel model = JsonConvert.DeserializeObject<UsuarioAutenticadoModel>(ticket.Name);

                        string[] roles = { model.GrupoUsuario };

                        HttpContext.Current.User = new GenericPrincipal(id, roles);

                    }

                }

            }
        }
    }
}
