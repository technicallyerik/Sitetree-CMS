using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using Sitetree.Core;
using Sitetree.Core.DataAccess.Services.Interfaces;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof (ApplicationStart), "Start")]

namespace Sitetree.Core
{
    /// <summary>
    ///     Class containing post-Application Start events
    /// </summary>
    public class ApplicationStart
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (PreApplicationStart));

        public static void Start()
        {
            PerformDatabaseMigrations();
            WireUpRouting();
            Log.Info("Sitetree started.");
        }

        /// <summary>
        ///     Perform un-executed database migrations
        /// </summary>
        private static void PerformDatabaseMigrations()
        {
            Log.Info("Performing database migrations...");
            var databaseMigrationService = DependencyResolver.Current.GetService<IDatabaseMigrationService>();
            databaseMigrationService.PerformMigrations();
        }

        /// <summary>
        ///     Configure base application routing
        /// </summary>
        private static void WireUpRouting()
        {
            Log.Info("Wiring up default routing...");
            var routes = RouteTable.Routes;

            // Prevent web resource files from being downloaded
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Reigster areas
            AreaRegistration.RegisterAllAreas();

            // Map MVC Attribute Routes
            routes.MapMvcAttributeRoutes();

            // Map WebAPI Attribute Routes
            GlobalConfiguration.Configure(configuration => configuration.MapHttpAttributeRoutes());
        }
    }
}