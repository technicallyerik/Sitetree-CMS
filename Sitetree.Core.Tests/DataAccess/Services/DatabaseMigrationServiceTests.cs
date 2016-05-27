using System.Linq;
using MigSharp;
using Sitetree.Core.DataAccess.Services;
using Xunit;

namespace Sitetree.Core.Tests.DataAccess.Services
{
    [MigrationExport(ModuleName = "Test.Migration")]
    public class TestMigration : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
        }

        public void Down(IDatabase db)
        {
        }
    }

    public class DatabaseMigrationServiceTests
    {
        [Fact]
        public void GetGroupedMigrationAssemblies_Should_Return_Test_Assembly()
        {
            var dbMigrationService = new DatabaseMigrationService();
            var groupedMigrationAssemblies = dbMigrationService.GetGroupedMigrationAssemblies();
            var flattenedAssemblies = groupedMigrationAssemblies.SelectMany(a => a);

            Assert.Contains(typeof (DatabaseMigrationServiceTests).Assembly, flattenedAssemblies);
        }

        [Fact]
        public void GetGroupedMigrationAssemblies_Should_Return_Sitetree_Assemblies_First()
        {
            var dbMigrationService = new DatabaseMigrationService();
            var groupedMigrationAssemblies = dbMigrationService.GetGroupedMigrationAssemblies();
            var firstAssemblyGroup = groupedMigrationAssemblies.First();

            Assert.Equal(true, firstAssemblyGroup.Key);
            Assert.Contains(typeof (DatabaseMigrationServiceTests).Assembly, firstAssemblyGroup);
        }
    }
}