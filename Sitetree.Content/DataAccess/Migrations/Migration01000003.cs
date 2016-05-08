using System.Data;
using MigSharp;

namespace Sitetree.Content.DataAccess.Migrations
{
    /// <summary>
    ///     Migration 1.0.0 #3 - Pages and PageData.
    /// </summary>
    [MigrationExport(ModuleName = "Sitetree.Core")]
    public class Migration01000003 : IReversibleMigration
    {
        public const string PagesTableName = "Pages";
        public const string PageDataTableName = "PageData";

        public void Up(IDatabase db)
        {
            
            db.CreateTable(PagesTableName)
                .WithPrimaryKeyColumn("Id", DbType.Guid)
                .WithNotNullableColumn("SiteId", DbType.Guid)
                .WithNullableColumn("ParentId", DbType.Guid)
                .WithNotNullableColumn("Name", DbType.String)
                .WithNotNullableColumn("Slug", DbType.String)
                .WithNotNullableColumn("Type", DbType.String);

            db.Tables[PagesTableName].AddIndex().OnColumn("SiteId");
            db.Tables[PagesTableName].AddForeignKeyTo("Sites").Through("SiteId", "Id");
            db.Tables[PagesTableName].AddForeignKeyTo(PagesTableName).Through("ParentId", "Id");

            db.CreateTable(PageDataTableName)
                .WithPrimaryKeyColumn("Id", DbType.Guid)
                .WithNotNullableColumn("PageId", DbType.Guid)
                .WithNotNullableColumn("Property", DbType.String)
                .WithNotNullableColumn("Value", DbType.String);

            db.Tables[PageDataTableName].AddForeignKeyTo(PagesTableName).Through("PageId", "Id");
            db.Tables[PageDataTableName].AddIndex().OnColumn("PageId");
        }

        public void Down(IDatabase db)
        {
            db.Tables[PageDataTableName].Drop();
            db.Tables[PagesTableName].Drop();
        }
    }
}