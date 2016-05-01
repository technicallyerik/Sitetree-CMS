using System;
using System.Web;
using System.Web.Routing;

namespace SiteTree.Web.Routing
{
    public class DefaultCmsHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;

            context.Response.Write("router");
        }

        public bool IsReusable => true;
    }
}
