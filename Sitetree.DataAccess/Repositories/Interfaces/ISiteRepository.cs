using System.Collections.Generic;
using Sitetree.DataAccess.Models;

namespace Sitetree.DataAccess.Repositories.Interfaces
{
    public interface ISiteRepository
    {
        List<Site> GetAllWithDomainsAndPages();
    }
}