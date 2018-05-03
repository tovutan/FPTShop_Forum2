using System.Web;
using System.Web.Optimization;

namespace FPTShop_Forum2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // Css thêm vào
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       //"~/Content/bootstrap.css",
                       //"~/Content/site.css",
                       "~/Content/popup-bootstrap.css",
                      "~/Content/reset.css",
                      "~/Content/header.footer.css",
                      "~/Content/style.css"
                      ));


            // script nằm ở head
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                    "~/Scripts/libs/ie-emulation-modes-warning.js",
                    "~/Scripts/libs/jquery-3.2.0.min.js"
                    //"~/Scripts/libs/jquery-1.11.2.min.js"
                ));
            // script nằm cuối body
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/libs/popup-bootstrap.min.js",
                "~/Scripts/functions.js"
                ));
        }
    }
}
