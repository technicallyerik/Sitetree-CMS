using MigSharp;

namespace Sitetree.Media.DataAccess.Migrations
{
    /// <summary>
    ///     Migration 1.0.0 #4 - Media.
    /// </summary>
    [MigrationExport(ModuleName = "Sitetree.Core")]
    public class Migration01000004 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
        }

        public void Down(IDatabase db)
        {
        }
    }
}