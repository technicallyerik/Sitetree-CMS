using System.Data;
using System.Data.SqlClient;
using Sitetree.Core.Helpers;

namespace Sitetree.Core.DataAccess.Repositories
{
    /// <summary>
    ///     Base repository class with common functionality.
    /// </summary>
    public abstract class BaseRepository
    {
        protected readonly IDbConnection Db = new SqlConnection(SitetreeConfiguration.ConnectionString);
    }
}