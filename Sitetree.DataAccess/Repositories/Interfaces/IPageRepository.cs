using System;
using Sitetree.DataAccess.Models;

namespace Sitetree.DataAccess.Repositories.Interfaces
{
    public interface IPageRepository
    {
        Page GetByIdWithData(Guid guid);
    }
}