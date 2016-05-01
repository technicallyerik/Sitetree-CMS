using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SiteTree.Web.Routing
{
    public class CmsRoutingHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        public void Dispose()
        {
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            AddCmsRouteToEndOfRoutingTable();
        }

        private static void AddCmsRouteToEndOfRoutingTable()
        {
            if (RouteTable.Routes.Contains(CmsRoute.Singleton))
                return;

            using (RouteTable.Routes.GetWriteLock())
            {
                if (RouteTable.Routes.Contains(CmsRoute.Singleton))
                    return;

                RouteTable.Routes.Add(CmsRoute.Singleton);
            }
        }
    }
}