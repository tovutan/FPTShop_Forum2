using System.Web.Mvc;

namespace FPTShop_Forum2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller="Post" ,action = "Index", id = UrlParameter.Optional },
                new[] {"FPTShop_Forum2.Areas.Admin.Controllers"}
            );
        }
    }
}