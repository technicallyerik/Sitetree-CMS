using System.Collections.Generic;
using System.Linq;
using Sitetree.Content.Models;

namespace Sitetree.Content.Extensions
{
    /// <summary>
    ///     Helper extensions for collections of pages
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        ///     Get the homepage from the list of pages.  A homepage
        ///     is designated by a null 'ParentId'.
        /// </summary>
        /// <param name="pages"><see cref="Page" />s for a site.</param>
        /// <returns>The Home <see cref="Page" /> for a site.</returns>
        public static Page GetHomepage(this List<Page> pages)
        {
            return pages.FirstOrDefault(p => p.ParentId == null);
        }
    }
}