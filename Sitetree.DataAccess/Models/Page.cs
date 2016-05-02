using System;
using System.Collections.Generic;

namespace Sitetree.DataAccess.Models
{
    public class Page
    {
        public Page()
        {
            Children = new List<Page>();
            Data = new List<PageData>();
        }

        public Guid Id { get; set; }

        public Guid SiteId { get; set; }

        public Site Site { get; set; } 

        public Guid? ParentId { get; set; }

        public Page Parent { get; set; }

        public List<Page> Children { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Type { get; set; }

        public List<PageData> Data { get; set; }
    }
}