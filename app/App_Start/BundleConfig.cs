using System;
using System.Web;
using System.Web.Optimization;

namespace app
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/mansory").Include(
                "~/Scripts/imagesloaded.pkgd.min.js",
                "~/Scripts/mansory_lib.js",
                "~/Scripts/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajaxjs").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css",
                "~/Content/main.css",
                "~/Content/countries.css",
                "~/Content/one_country.css",
                "~/Content/tests.css",
                "~/Content/one_test.css"
                ));

        } 
    }
}
