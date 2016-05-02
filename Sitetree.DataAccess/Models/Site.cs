using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitetree.DataAccess.Models
{
    public class Site
    {
        public Site()
        {
            Pages = new List<Page>();
            Domains = new List<SiteDomain>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Page> Pages { get; set; }

        public List<SiteDomain> Domains { get; set; } 

        public Page Homepage => Pages.FirstOrDefault(p => p.ParentId == null);
    }
}