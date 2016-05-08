using System.Collections.Generic;
using System.Linq;
using Dapper;
using Sitetree.Core.DataAccess.Repositories.Interfaces;
using Sitetree.Core.Models;

namespace Sitetree.Core.DataAccess.Repositories
{
    public class SiteRepository : BaseRepository, ISiteRepository
    {
        public List<Site> GetAllSitesWithDomains()
        {
            var query = @"select * from Sites s
                left join SiteDomains d on d.SiteId = s.Id";

            return _db.Query<Site, SiteDomain, Site>(
                query,
                (site, domain) =>
                {
                    site.Domains.Add(domain);
                    domain.Site = site;
                    return site;
                }).ToList();
        }
    }
}