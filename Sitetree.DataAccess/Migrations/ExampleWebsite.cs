using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Sitetree.DataAccess.Migrations
{
    [Profile("ExampleWebsite")]
    public class ExampleWebsite : Migration
    {
        public override void Up()
        {
            var siteGuid = Guid.NewGuid();
            var pageGuid = Guid.NewGuid();

            Insert.IntoTable("Sites").Row(new
            {
                Id = siteGuid,
                Name = "Example Website"
            });

            Insert.IntoTable("Pages").Row(new
            {
                Id = pageGuid,
                SiteId = siteGuid,
                ParentId = (Guid?)null,
                Name = "Home Page",
                Slug = "",
                Type = "Home"
            });

            Insert.IntoTable("PageData").Row(new
            {
                Id = Guid.NewGuid(),
                PageId = pageGuid,
                Property = "Heading",
                Value = "Welcome to my homepage!"
            });
        }

        public override void Down()
        {
            //empty, not using
        }
    }
}
