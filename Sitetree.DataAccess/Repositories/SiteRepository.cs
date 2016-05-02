using System.Collections.Generic;
using System.Linq;
using Dapper;
using Sitetree.DataAccess.Models;
using Sitetree.DataAccess.Repositories.Interfaces;

namespace Sitetree.DataAccess.Repositories
{
    public class SiteRepository : BaseRepository, ISiteRepository
    {
        public List<Site> GetAllWithDomainsAndPages()
        {
            string query = @"select * from Sites s
                left join SiteDomains d on d.SiteId = s.Id
                select * from Pages p";

            using (var multi = _db.QueryMultiple(query))
            {
                var sites = multi.Read<Site, SiteDomain, Site>((site, domain) =>
                {
                    site.Domains.Add(domain);
                    domain.Site = site;
                    return site;
                }).ToList();

                var pages = multi.Read<Page>().ToList();
                var pageDictionary = pages.ToDictionary(p => p.Id, p => p);
                foreach (var page in pages)
                {
                    if (page.ParentId.HasValue)
                    {
                        var parent = pageDictionary[page.ParentId.Value];
                        page.Parent = parent;
                        parent.Children.Add(page);
                    }
                }

                foreach (var site in sites)
                {
                    site.Pages = pages.Where(p => p.SiteId == site.Id).ToList();
                }

                return sites;
            }
        }
    }
}