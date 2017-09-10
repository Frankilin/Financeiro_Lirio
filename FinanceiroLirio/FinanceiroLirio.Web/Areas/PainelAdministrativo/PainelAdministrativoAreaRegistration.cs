using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.PainelAdministrativo
{
    public class PainelAdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PainelAdministrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PainelAdministrativo_default",
                "PainelAdministrativo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}