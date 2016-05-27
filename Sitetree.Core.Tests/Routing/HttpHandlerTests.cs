using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using Moq;
using Sitetree.Core.Helpers;
using Sitetree.Core.Routing;
using Sitetree.Core.Routing.Interfaces;
using Xunit;

namespace Sitetree.Core.Tests.Routing
{
    public class HttpHandlerTests
    {
        [Fact]
        public void HttpHandler_Should_Execute_Custom_Request_Handler()
        {
            // Setup Mock
            CatalogContainer.Singleton = new CompositionContainer();
            var mock = new Mock<IRequestHandler>();
            var handler = new HttpHandler();
            handler.RequestHandlers = new List<IRequestHandler> {mock.Object};

            // Execute
            handler.ProcessRequest(null);

            // Verify
            mock.Verify(m => m.HandleRequest(null), Times.Exactly(1));
        }
    }
}