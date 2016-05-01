using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitetree.DataAccess.Models
{
    public class Page
    {
        public Guid Id { get; set; }
        
        public Guid SiteId { get; set; }

        public Guid? ParentId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Type { get; set; }
    }
}
