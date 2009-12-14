using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DABE.Core.Infrastructure;
using DABE.Web.MetaBlog;
using NHibernate.Cfg;

namespace DABE.Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                );

        }

        protected void Application_Start()
        {
            
            RegisterRoutes(RouteTable.Routes);


            Bootstrapper.Init(this);

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            ModelBinders.Binders.Add(typeof(MetaBlogRequest), new MetaBlogRequestBinder());
        }
    }
}