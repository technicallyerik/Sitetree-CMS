using System;
using System.Linq;
using System.Reflection;
using MigSharp;
using Sitetree.Core.DataAccess.Services.Interfaces;
using Sitetree.Core.Helpers;

namespace Sitetree.Core.DataAccess.Services
{
    /// <summary>
    ///     Service to handle database migrations.
    /// </summary>
    public class DatabaseMigrationService : IDatabaseMigrationService
    {
        /// <summary>
        ///     Perform all database migrations that implement <see cref="IMigration" /> and
        ///     use the <see cref="MigrationExportAttribute" />.
        /// </summary>
        /// <remarks>
        ///     Migrations in libraries starting with the namespace 'Sitetree.' are
        ///     executed first.  This namespace should be reserved to core Sitetree libraries.
        /// </remarks>
        public void PerformMigrations()
        {
            var dbPlatform = new DbPlatform(SitetreeConfiguration.DbPlatform, SitetreeConfiguration.DbVersion);
            var migrator = new Migrator(SitetreeConfiguration.ConnectionString, dbPlatform);

            var groupedMigrationAssemblies = GetGroupedMigrationAssemblies();
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
        ///     Get all assemblies containing migrations, starting with core "Sitetree." ones
        /// </summary>
        internal IOrderedEnumerable<IGrouping<bool, Assembly>> GetGroupedMigrationAssemblies()
        {
            var migrationType = typeof (IMigration);
            var migrationAttribute = typeof (MigrationExportAttribute);
            var migrationAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetTypes().Any(t => migrationType.IsAssignableFrom(t) &&
                                                  Attribute.IsDefined(t, migrationAttribute))).ToArray();
            var groupedMigrationAssemblies =
                migrationAssemblies.GroupBy(a => a.FullName.StartsWith("Sitetree.")).OrderByDescending(g => g.Key);
            return groupedMigrationAssemblies;
        }
    }
}
