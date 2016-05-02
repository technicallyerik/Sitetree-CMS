using System;

namespace Sitetree.DataAccess.Models
{
    public class SiteDomain
    {
        public Guid Id { get; set; }

        public Guid SiteId { get; set; }

        public Site Site { get; set; }

        public string Domain { get; set; }
    }
}