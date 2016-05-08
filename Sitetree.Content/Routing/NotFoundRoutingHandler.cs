using System.ComponentModel.Composition;
using System.Web;
using Sitetree.Core.Routing.Interfaces;

namespace Sitetree.Content.Routing
{
    [Export(typeof (IRequestHandler))]
    public class NotFoundRoutingHandler : IRequestHandler
    {
        public int Order => int.MaxValue;

        public bool HandleRequest(HttpContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.Write("404 Not Found");
            return true;
        }
    }
}