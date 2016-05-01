using System.Web.Routing;

namespace SiteTree.Web.Routing
{
    public class CmsRoute : Route
    {
        static readonly CmsRoute _singleton = new CmsRoute();

        public static CmsRoute Singleton => _singleton;

        private CmsRoute() : base("{*path}", new CmsRouteHandler())
        {

        }
    }
}