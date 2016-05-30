using System.Web.Optimization;

namespace PairingTest.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/styles/all.css")
                 .Include("~/font-awesome/css/font-awesome.css")
                 .Include("~/styles/bootstrap.css")                 
                 );
            
            bundles.Add(new ScriptBundle("~/Scripts/all.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/ui-bootstrap.js")
                .Include("~/Scripts/app/app.js")
                .IncludeDirectory("~/Scripts/app/", "*.js", true)
                );
        }
    }
}