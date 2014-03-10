using System.Web;
using System.Web.Optimization;

namespace Monsterbutikken
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                "~/Scripts/app/app.js",
                "~/Scripts/app/monstersService.js",
                "~/Scripts/app/basketService.js",
                "~/Scripts/app/authService.js",
                "~/Scripts/app/orderService.js",
                "~/Scripts/app/loginController.js",
                "~/Scripts/app/shopControllers.js"));

            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-mocks.js"));

            bundles.Add(new ScriptBundle("~/bundles/Bootstrap").Include(
                "~/Scripts/ui-bootstrap-tpls-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css"));
        }
    }
}
