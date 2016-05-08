using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MigSharp;
using Sitetree.Core;
using Sitetree.Core.Helpers;
using Sitetree.Core.Routing;

[assembly: PreApplicationStartMethod(typeof (PreApplicationStart), "Start")]

namespace Sitetree.Core
{
    /// <summary>
    ///     Class containing pre-application startup events
    /// </summary>
    public class PreApplicationStart
    {
        public static void Start()
        {
            PerformDatabaseMigrations();
            WireUpRouting();
            SetupAutofac();
        }

        /// <summary>
        ///     Perform all database migrations that implement <see cref="IMigration" /> and
        ///     use the <see cref="MigrationExportAttribute" />.
        /// </summary>
        /// <remarks>
        ///     Migrations in libraries starting with the namespace 'Sitetree.' are
        ///     executed first.  This namespace should be reserved to core Sitetree libraries.
        /// </remarks>
        private static void PerformDatabaseMigrations()
        {
            var dbPlatform = new DbPlatform(SitetreeConfiguration.DbPlatform, SitetreeConfiguration.DbVersion);
            var migrator = new Migrator(SitetreeConfiguration.ConnectionString, dbPlatform);

            var migrationType = typeof (IMigration);
            var migrationAttribute = typeof (MigrationExportAttribute);
            var migrationAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetTypes().Any(t => migrationType.IsAssignableFrom(t) &&
                                                  Attribute.IsDefined(t, migrationAttribute))).ToArray();
            var groupedMigrationAssemblies =
                migrationAssemblies.GroupBy(a => a.FullName.StartsWith("Sitetree.")).OrderByDescending(g => g.Key);
                // Ensure core migrations are run first
            foreach (var groupedMigrationAssembly in groupedMigrationAssemblies)
            {
                var migrations = groupedMigrationAssembly.ToList();
                if (migrations.Any())
                {
                    migrator.MigrateAll(migrations.First(), migrations.Skip(1).ToArray());
                }
            }
        }

        /// <summary>
        ///     Loads the <see cref="RoutingHttpModule" /> to kick off routing setup.
        /// </summary>
        private static void WireUpRouting()
        {
            DynamicModuleUtility.RegisterModule(typeof (RoutingHttpModule));
        }

        /// <summary>
        ///     Register all autofac modules and set default resolver.
        /// </summary>
        private static void SetupAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (PreApplicationStart).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();
            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}