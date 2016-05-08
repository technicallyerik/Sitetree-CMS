using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Sitetree.Core;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(ApplicationStart), "Start")]
namespace Sitetree.Core
{
    public class ApplicationStart
    {
        public static void Start()
        {
            WireUpRouting();
        }

        private static void WireUpRouting()
        {
            var routes = RouteTable.Routes;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            AreaRegistration.RegisterAllAreas();
            routes.MapMvcAttributeRoutes();
            GlobalConfiguration.Configure(configuration => configuration.MapHttpAttributeRoutes());
        }
    }
}
