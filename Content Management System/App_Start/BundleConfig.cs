using System.Web;
using System.Web.Optimization;

namespace Content_Management_System
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/CMSjquery").Include(
                        "~/Scripts/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Content/select2/dist/js/select2.full.min.js",
                        "~/Scripts/input-mask/jquery.inputmask.js",
                        "~/Scripts/jquery.inputmask.date.extensions.js",
                        "~/Scripts/jquery.inputmask.extensions.js",
                        "~/Scripts/moment/min/moment.min.js",
                        "~/Content/bootstrap-daterangepicker/daterangepicker.js",
                        "~/Content/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                        "~/Content/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                        "~/Content/timepicker/bootstrap-timepicker.min.js",
                        "~/Scripts/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Content/iCheck/icheck.min.js",
                        "~/Scripts/fastclick/lib/fastclick.js",
                        "~/Scripts/adminlte.min.js",
                        "~/Scripts/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/CMScss").Include(
                      "~/Content/font-awesome/css/font-awesome.min.css",
                      "~/Content/Ionicons/css/ionicons.min.css",
                      "~/Content/datatables.net-bs/css/dataTables.bootstrap.min.css",
                      "~/Content/bootstrap-daterangepicker/daterangepicker.css",
                      "~/Content/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                      "~/Content/iCheck/all.css",
                      "~/Content/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css",
                      "~/Content/timepicker/bootstrap-timepicker.min.css",
                      "~/Content/select2/dist/css/select2.min.css", 
                      "~/Content/AdminLTE.min.css",
                      "~/Content/_all-skins.min.css"));
        }
    }
}
