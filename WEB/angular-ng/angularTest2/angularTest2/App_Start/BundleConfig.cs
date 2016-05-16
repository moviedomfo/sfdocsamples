using System.Configuration;
using System.Web;
using System.Web.Optimization;

namespace angularTest2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));



            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                                "~/Scripts/site.js",
                                "~/Scripts/Site-helpers.js",
                                "~/Scripts/jquery.numeric.js"
                                ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
             "~/Scripts/angular.js",
             "~/Scripts/angular-route.js",
                "~/Scripts/underscore-min.js",
             "~/Scripts/restangular.js"
             
             ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                //"~/Scripts/bootstrap-datepicker.min.js"

                 ));
            //// Enable optimisation based on web.config setting
            //BundleTable.EnableOptimizations =
            //    bool.Parse(ConfigurationManager.AppSettings["BundleOptimisation"]);
        }
    }
}
