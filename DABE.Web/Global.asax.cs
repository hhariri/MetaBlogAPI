using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DABE.Web.MetaBlog;

namespace DABE.Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            Bootstrapper.Init();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            ModelBinders.Binders.Add(typeof(MetaBlogGetUsersBlogRequest), new MetaBlogGetUsersBlogRequestBinder());
        }
    }
}