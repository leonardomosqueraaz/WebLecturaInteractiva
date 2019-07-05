using System.Web;
using System.Web.Optimization;

namespace WebLecturaInteractiva
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/plugins/sweetalert/sweetalert.min.js",
                      "~/Content/plugins/jquery/jquery.min.js",
                      "~/Content/plugins/bootstrap/js/bootstrap.js",
                      "~/Content/plugins/bootstrap-select/js/bootstrap-select.js",
                      "~/Content/plugins/jquery-slimscroll/jquery.slimscroll.js",
                      "~/Content/plugins/node-waves/waves.js",
                      "~/Content/plugins/momentjs/moment.js",
                      "~/Content/plugins/autosize/autosize.js",
                      "~/Content/plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js",
                      "~/Content/plugins/nestable/jquery.nestable.js",
                      "~/Content/js/admin.js",
                      "~/Content/js/pages/forms/form-wizard.js",
                      "~/Content/js/pages/ui/sortable-nestable.js",
                      "~/Content/plugins/bootstrap-select/js/bootstrap-select.js",
                      "~/Content/js/demo.js",
                      "~/Content/js/pages/forms/basic-form-elements.js",
                      "~/Content/js/pages/ui/modals.js",
                      "~/Content/plugins/sweetalert/sweetalert.min.js",
                      "~/Content/plugins/jquery-validation/jquery.validate.js",
                      "~/Content/plugins/jquery-steps/jquery.steps.js",
                      "~/Content/plugins/sweetalert/sweetalert.min.js",
                      "~/Content/plugins/multi-select/js/jquery.multi-select.js",
                      "~/Content/js/global.js"));
            //"~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/plugins/bootstrap/css/bootstrap.css",
                      "~/Content/plugins/node-waves/waves.css",
                      "~/Content/plugins/bootstrap-select/css/bootstrap-select.css",
                      "~/Content/plugins/animate-css/animate.css",
                      "~/Content/plugins/sweetalert/sweetalert.css",
                      "~/Content/css/themes/all-themes.css",
                      "~/Content/css/style.css",
                      "~/Content/plugins/nestable/jquery-nestable.css",
                      "~/Content/plugins/sweetalert/sweetalert.css",
                      "~/Content/plugins/multi-select/css/multi-select.css"));
            //"~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
