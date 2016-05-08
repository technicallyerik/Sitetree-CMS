using System;
using System.Collections.Generic;
using Sitetree.Content.Models;

namespace Sitetree.Content.DataAccess.Repositories.Interfaces
{
    public interface IPageRepository
    {
        /// <summary>
        ///     Gets a list of <see cref="Page"/>s by a site guid, without data populated.
        /// </summary>
        /// <param name="guid">Guid of the site.</param>
        /// <returns>List of <see cref="Page"/>s in the site.</returns>
        List<Page> GetPagesBySite(Guid guid);

        /// <summary>
        ///     Gets a <see cref="Page"/> populated with <see cref="PageData"/>
        ///     by a page guid.
        /// </summary>
        /// <param name="guid">Guid of the page.</param>
        /// <returns>A <see cref="Page"/> populated with <see cref="PageData"/>.</returns>
        Page GetPageByIdWithData(Guid guid);
    }
}