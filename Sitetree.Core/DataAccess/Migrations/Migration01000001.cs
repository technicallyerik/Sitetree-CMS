using System.Data;
using MigSharp;

namespace Sitetree.Core.DataAccess.Migrations
{
    /// <summary>
    ///     Migration 1.0.0 #1 - Sites and SiteDomains.
    /// </summary>
    [MigrationExport(ModuleName = "Sitetree.Core")]
    public class Migration01000001 : IReversibleMigration
    {
        public const string SitesTableName = "Sites";
        public const string SiteDomainsTableName = "SiteDomains";

        public void Up(IDatabase db)
        {
            
            db.CreateTable(SitesTableName)
                .WithPrimaryKeyColumn("Id", DbType.Guid)
                .WithNotNullableColumn("Name", DbType.String);
            
            db.CreateTable(SiteDomainsTableName)
                .WithPrimaryKeyColumn("Id", DbType.Guid)
                .WithNotNullableColumn("SiteId", DbType.Guid)
                .WithNotNullableColumn("Domain", DbType.String);

            db.Tables[SiteDomainsTableName].AddForeignKeyTo(SitesTableName).Through("SiteId", "Id");
        }

        public void Down(IDatabase db)
        {
            db.Tables[SiteDomainsTableName].Drop();
            db.Tables[SitesTableName].Drop();
        }
    }
}