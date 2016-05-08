using System.Web.Routing;

namespace Sitetree.Core.Routing
{
    /// <summary>
    ///     Represents a global catch-all route for Sitetree to handle all routing with.
    /// </summary>
    public class SitetreeRoute : Route
    {
        static readonly SitetreeRoute _singleton = new SitetreeRoute();

        /// <summary>
        ///     Singleton copy of a <see cref="SitetreeRoute"/>.
        /// </summary>
        public static SitetreeRoute Singleton => _singleton;

        private SitetreeRoute() : base("{*path}", new RouteHandler())
        {

        }
    }
}