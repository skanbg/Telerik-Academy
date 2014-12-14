namespace ForumSystem.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterStyleBundles(bundles);
            RegisterScriptBundles(bundles);

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Kendo")
                .Include("~/Scripts/Kendo/kendo.all.min.js", "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/Kendo/jquery.min.js", "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.cosmo.css"));
            bundles.Add(new StyleBundle("~/Content/Kendo/Source")
                .Include(
                "~/Content/Kendo/kendo.common.min.css",
                "~/Content/Kendo/kendo.common-bootstrap.min.css",
                "~/Content/Kendo/kendo.silver.min.css"));
            bundles.Add(new StyleBundle("~/Content/custom")
                .Include("~/Content/site.css"));
        }
    }
}
