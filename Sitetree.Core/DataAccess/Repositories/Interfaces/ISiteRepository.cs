using System.Collections.Generic;
using Sitetree.Core.Models;

namespace Sitetree.Core.DataAccess.Repositories.Interfaces
{
    /// <summary>
    ///     Repository to get information about the setup sites
    /// </summary>
    public interface ISiteRepository
    {
        /// <summary>
        ///     Get all sites with domain information loaded
        /// </summary>
        List<Site> GetAllSitesWithDomains();
    }
}