using System.Collections.Generic;
using Sitetree.Core.Models;

namespace Sitetree.Core.DataAccess.Repositories.Interfaces
{
    public interface ISiteRepository
    {
        List<Site> GetAllSitesWithDomains();
    }
}