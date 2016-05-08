using System.Web;

namespace Sitetree.Core.Routing.Interfaces
{
    /// <summary>
    ///     Indicates that this class handles routing in the CMS.
    /// </summary>
    public interface IRequestHandler
    {
        /// <summary>
        ///     The order that the request is handled relative to other request handlers
        ///     registered in the CMS.  Numbers below '100' should be reserved
        ///     to core Sitetree routing, and 'Int32.MaxValue' is reserved
        ///     for the core not found handler.
        /// </summary>
        int Order { get; }

        /// <summary>
        ///     Handle the incoming request.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext" /> of the request.</param>
        /// <returns>Returns 'true' if the request was handled.</returns>
        bool HandleRequest(HttpContext context);
    }
}