using System;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Sitetree.Core;
using Sitetree.Core.Routing;

[assembly: PreApplicationStartMethod(typeof (PreApplicationStart), "Start")]

namespace Sitetree.Core
{
    /// <summary>
    ///     Class containing pre-application startup events
    /// </summary>
    public class PreApplicationStart
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (PreApplicationStart));

        public static void Start()
        {
            Log.Info("Starting Sitetree...");
            SetupAutofac();
            WireUpRouting();
        }

        /// <summary>
        ///     Register all autofac modules and set default resolver.
        /// </summary>
        private static void SetupAutofac()
        {
            Log.Info("Setting up Autofac...");
            var builder = new ContainerBuilder();

            // Register MVC controllers
            builder.RegisterControllers(typeof (PreApplicationStart).Assembly);

            // Register web abstractions like HttpContextBase
            builder.RegisterModule<AutofacWebTypesModule>();

            // Enable property injection into action filters
            builder.RegisterFilterProvider();

            // Register all modules
            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());

            var container = builder.Build();

            // Set default resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        ///     Configure custom routing for Sitetree
        /// </summary>
        private static void WireUpRouting()
        {
            Log.Info("Setting up Sitetree routing...");
            DynamicModuleUtility.RegisterModule(typeof (RoutingHttpModule));
        }
    }
}