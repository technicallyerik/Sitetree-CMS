using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Sitetree.Core.Helpers;
using Sitetree.Core.Routing.Interfaces;

namespace Sitetree.Core.Routing
{
    /// <summary>
    ///     Handles a reqeust to the CMS, and passes it onto any registered 
    ///     <see cref="IRequestHandler"/> classes for processing.
    /// </summary>
    public class HttpHandler : IHttpHandler
    {
        public HttpHandler()
        {
            CatalogContainer.Current.SatisfyImportsOnce(this);
        }

        [ImportMany(typeof(IRequestHandler))]
        private IEnumerable<IRequestHandler> requestHandlers;

        public void ProcessRequest(HttpContext context)
        {
            if (requestHandlers != null)
            {
                foreach (var requestHandler in requestHandlers.OrderBy(h => h.Order))
                {
                    var result = requestHandler.HandleRequest(context);

                    if (result)
                        return;
                }
            }
        }

        public bool IsReusable => true;
    }
}