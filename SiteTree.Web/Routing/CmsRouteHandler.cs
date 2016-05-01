using System.Web;
using System.Web.Routing;

namespace SiteTree.Web.Routing
{
    public class CmsRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new DefaultCmsHttpHandler();
        }
    }
}