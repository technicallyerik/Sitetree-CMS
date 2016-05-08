using System;

namespace Sitetree.Content.Models
{
    /// <summary>
    ///     Represents a piece of data on a page
    /// </summary>
    public class PageData
    {
        public Guid Id { get; set; }

        public Guid PageId { get; set; }

        public Page Page { get; set; }

        public string Property { get; set; }

        public string Value { get; set; }
    }
}