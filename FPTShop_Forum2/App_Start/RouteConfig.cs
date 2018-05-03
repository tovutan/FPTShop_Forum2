using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FPTShop_Forum2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //routes.MapRoute(
            //    "ListChildCategory",
            //    "child/{catChildURL}",
            //    new { controller = "Home", action = "ListChildCategory", queryValues = UrlParameter.Optional },
            //    new[] { "FPTShop_Forum2.Controllers" }
            //    );


            routes.MapRoute(
                "LoadPostNotNameCategory",
                "page/{catURL}",
                new {controller="Home",action= "LoadPostNotNameCategory", queryValues=UrlParameter.Optional },
                new[] {"FPTShop_Forum2.Controllers" }
                );

            routes.MapRoute(
                "LoadPostNameCategory",
                "username/size/{categoryUrl}",
                new { controller="Home",action= "LoadPostNameCategory",queryValues=UrlParameter.Optional },
                new[] {"FPTShop_Forum2.Controllers" }
                );

            routes.MapRoute(
                "Ajax",
                "Ajax/{controller}/{action}",
                new[] {"FPTShop_Forum2.Controllers" }
                );

            routes.MapRoute(
                "ListPostCategory",
                "{catURL}",
                new { controller = "Home", action = "ListPostCategory", queryValues = UrlParameter.Optional },
                new[] {"FPTShop_Forum2.Controllers"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new[] {"FPTShop_Forum2.Controllers"}
            );
        }
    }
}
