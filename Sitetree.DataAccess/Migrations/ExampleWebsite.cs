using System;
using FluentMigrator;

namespace Sitetree.DataAccess.Migrations
{
    [Profile("ExampleWebsite")]
    public class ExampleWebsite : Migration
    {
        public override void Up()
        {
            var siteGuid = Guid.NewGuid();
            Insert.IntoTable("Sites").Row(new
            {
                Id = siteGuid,
                Name = "Example Website"
            });

            Insert.IntoTable("SiteDomains").Row(new
            {
                Id = Guid.NewGuid(),
                SiteId = siteGuid,
                Domain = "example.local"
            });

            var homepageGuid = Guid.NewGuid();
            Insert.IntoTable("Pages").Row(new
            {
                Id = homepageGuid,
                SiteId = siteGuid,
                ParentId = (Guid?) null,
                Name = "Home Page",
                Slug = "",
                Type = "Home"
            });

            Insert.IntoTable("PageData").Row(new
            {
                Id = Guid.NewGuid(),
                PageId = homepageGuid,
                Property = "Heading",
                Value = "Welcome to my homepage!"
            });

            var aboutPageGuid = Guid.NewGuid();
            Insert.IntoTable("Pages").Row(new
            {
                Id = aboutPageGuid,
                SiteId = siteGuid,
                ParentId = homepageGuid,
                Name = "About",
                Slug = "about",
                Type = "About"
            });

            Insert.IntoTable("PageData").Row(new
            {
                Id = Guid.NewGuid(),
                PageId = aboutPageGuid,
                Property = "Heading",
                Value = "About Page"
            });

            var contactGuid = Guid.NewGuid();
            Insert.IntoTable("Pages").Row(new
            {
                Id = contactGuid,
                SiteId = siteGuid,
                ParentId = homepageGuid,
                Name = "Contact Us",
                Slug = "contact",
                Type = "Contact"
            });

            Insert.IntoTable("PageData").Row(new
            {
                Id = Guid.NewGuid(),
                PageId = contactGuid,
                Property = "Heading",
                Value = "Contact Us Below!"
            });

            var servicesGuid = Guid.NewGuid();
            Insert.IntoTable("Pages").Row(new
            {
                Id = servicesGuid,
                SiteId = siteGuid,
                ParentId = homepageGuid,
                Name = "Services Landing",
                Slug = "services",
                Type = "ServicesLanding"
            });

            Insert.IntoTable("PageData").Row(new
            {
                Id = Guid.NewGuid(),
                PageId = servicesGuid,
                Property = "Heading",
                Value = "These are the list of services offered:"
            });

            var developmentServicesGuid = Guid.NewGuid();
            Insert.IntoTable("Pages").Row(new
            {
                Id = developmentServicesGuid,
                SiteId = siteGuid,
                ParentId = servicesGuid,
                Name = "Development Services",
                Slug = "development",
                Type = "ServicesDetail"
            });

            Insert.IntoTable("PageData").Row(new
            {
                Id = Guid.NewGuid(),
                PageId = developmentServicesGuid,
                Property = "Heading",
                Value = "Software Development Services"
            });
        }

        public override void Down()
        {
            //empty, not using
        }
    }
}