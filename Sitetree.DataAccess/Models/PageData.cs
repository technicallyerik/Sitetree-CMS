using System;

namespace Sitetree.DataAccess.Models
{
    public class PageData
    {
        public Guid Id { get; set; }

        public Guid PageId { get; set; }

        public Page Page { get; set; }

        public string Property { get; set; }

        public string Value { get; set; }
    }
}