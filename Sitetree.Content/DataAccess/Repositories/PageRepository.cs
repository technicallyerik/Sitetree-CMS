using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Sitetree.Content.DataAccess.Repositories.Interfaces;
using Sitetree.Content.Models;
using Sitetree.Core.DataAccess.Repositories;

namespace Sitetree.Content.DataAccess.Repositories
{
    public class PageRepository : BaseRepository, IPageRepository
    {
        public List<Page> GetPagesBySite(Guid guid)
        {
            var query = @"select * from Pages p
            where p.SiteId = @Id";

            var pages = _db.Query<Page>(query, new { Id = guid }).ToList();
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
            return pages;
        }

        public Page GetPageByIdWithData(Guid guid)
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