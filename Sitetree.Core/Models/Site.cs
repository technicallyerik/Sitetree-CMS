using System;
using System.Collections.Generic;

namespace Sitetree.Core.Models
{
    /// <summary>
    ///     Represents the concept of a website in the CMS.
    /// </summary>
    public class Site
    {
        /// <summary>
        ///     Default constructor to initialize empty lists.
        /// </summary>
        public Site()
        {
            Domains = new List<SiteDomain>();
        }

        /// <summary>
        ///     The Id of the website.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     The name of the website.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The domains this site is accessable under.
        /// </summary>
        public List<SiteDomain> Domains { get; set; }
    }
}