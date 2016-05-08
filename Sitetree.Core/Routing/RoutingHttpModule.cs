using System;
using System.Web;
using System.Web.Routing;

namespace Sitetree.Core.Routing
{
    /// <summary>
    ///     An <see cref="IHttpModule"/> to inject Sitetree's catchall <see cref="SitetreeRoute"/>
    ///     into the end of the routing table.
    /// </summary>
    public class RoutingHttpModule : IHttpModule
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
            if (RouteTable.Routes.Contains(SitetreeRoute.Singleton))
                return;

            using (RouteTable.Routes.GetWriteLock())
            {
                if (RouteTable.Routes.Contains(SitetreeRoute.Singleton))
                    return;

                RouteTable.Routes.Add(SitetreeRoute.Singleton);
            }
        }
    }
}