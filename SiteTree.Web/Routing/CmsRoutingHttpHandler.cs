using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SiteTree.Web.Routing
{
    public class DefaultCmsHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {


            var request = context.Request;
            var requestContext = request.RequestContext;
            var path = (string)requestContext.RouteData.Values["path"] ?? string.Empty;
            var pathParts = path.Split('/');

            var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            var controller = controllerFactory.CreateController(requestContext, "Home");
            requestContext.RouteData.Values.Add("controller", "Home");
            requestContext.RouteData.Values.Add("action", "Index");
            controller.Execute(requestContext);

            //context.Response.Write("router");
        }

        public bool IsReusable => true;
    }
}
