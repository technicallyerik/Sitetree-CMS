using System;

namespace Sitetree.Core.Models
{
    /// <summary>
    ///     Represents a domain name for a website.
    /// </summary>
    public class SiteDomain
    {
        /// <summary>
        ///     The Id of the domain record.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     The Id of the <see cref="Site"/>.
        /// </summary>
        public Guid SiteId { get; set; }

        /// <summary>
        ///     The <see cref="Site"/> this domain is associated with.
        /// </summary>
        public Site Site { get; set; }

        /// <summary>
        ///     The domain name of the site.  Does not include 'http://'.
        /// </summary>
        public string Domain { get; set; }
    }
}