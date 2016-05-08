using System.Web.Mvc;
using System.Web.Routing;

namespace Sitetree.Example
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            AreaRegistration.RegisterAllAreas();

            routes.MapMvcAttributeRoutes();
        }
    }
}