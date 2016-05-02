using FluentMigrator;

namespace Sitetree.DataAccess.Migrations
{
    [Migration(1)]
    public class _1_SiteAndPageTables : Migration
    {
        public override void Up()
        {
            Create.Table("Sites")
                .WithDescription("Represents an individual site in the CMS.")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString();

            Create.Table("SiteDomains")
                .WithDescription("Represents a domain a site is accessable by.")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("SiteId").AsGuid().ForeignKey("Sites", "Id")
                .WithColumn("Domain").AsString();

            Create.Table("Pages")
                .WithDescription("Represents a page in a site.")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("SiteId").AsGuid().ForeignKey("Sites", "Id")
                .WithColumn("ParentId").AsGuid().Nullable().ForeignKey("Pages", "Id")
                .WithColumn("Name").AsString()
                .WithColumn("Slug").AsString()
                .WithColumn("Type").AsString();

            Create.Table("PageData")
                .WithDescription("Represents data on a page")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("PageId").AsGuid().ForeignKey("Pages", "Id")
                .WithColumn("Property").AsString()
                .WithColumn("Value").AsString();
        }

        public override void Down()
        {
            Delete.Table("PageData");
            Delete.Table("Pages");
            Delete.Table("Sites");
        }
    }
}