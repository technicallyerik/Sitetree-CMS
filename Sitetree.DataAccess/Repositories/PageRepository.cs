using System;
using System.Linq;
using Dapper;
using Sitetree.DataAccess.Models;
using Sitetree.DataAccess.Repositories.Interfaces;

namespace Sitetree.DataAccess.Repositories
{
    public class PageRepository : BaseRepository, IPageRepository
    {
        public Page GetByIdWithData(Guid guid)
        {
            var query = @"select * from Pages p
            left join PageData d on d.PageId = p.Id
            where p.Id = @Id";

            return _db.Query<Page, PageData, Page>(
                query,
                (page, data) =>
                {
                    page.Data.Add(data);
                    data.Page = page;
                    return page;
                },
                new {Id = guid}
                ).FirstOrDefault();
        }
    }
}