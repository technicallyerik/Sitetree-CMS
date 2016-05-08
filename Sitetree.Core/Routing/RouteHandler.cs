using System.Web;
using System.Web.Routing;

namespace Sitetree.Core.Routing
{
    /// <summary>
    ///     Handles the catchall <see cref="SitetreeRoute"/> and passes the request
    ///     onto Sitetree's <see cref="HttpHandler"/> for processing.
    /// </summary>
    public class RouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new HttpHandler();
        }
    }
}