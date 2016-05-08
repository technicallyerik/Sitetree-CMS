using MigSharp;

namespace Sitetree.Users.DataAccess.Migrations
{
    /// <summary>
    ///     Migration 1.0.0 #2 - Users and Groups.
    /// </summary>
    [MigrationExport(ModuleName = "Sitetree.Core")]
    public class Migration01000002 : IReversibleMigration
    {
        public void Up(IDatabase db)
        {
        }

        public void Down(IDatabase db)
        {
        }
    }
}