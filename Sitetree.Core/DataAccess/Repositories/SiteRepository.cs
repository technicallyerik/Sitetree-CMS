using System.Collections.Generic;
using System.Linq;
using Dapper;
using Sitetree.Core.DataAccess.Repositories.Interfaces;
using Sitetree.Core.Models;

namespace Sitetree.Core.DataAccess.Repositories
{
    /// <summary>
    ///     Repository to get information about the setup sites
    /// </summary>
    public class SiteRepository : BaseRepository, ISiteRepository
    {
        /// <summary>
        ///     Get all sites with domain information loaded
        /// </summary>
        public List<Site> GetAllSitesWithDomains()
        {
            const string query = @"select * from Sites s
                left join SiteDomains d on d.SiteId = s.Id";

            return Db.Query<Site, SiteDomain, Site>(
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