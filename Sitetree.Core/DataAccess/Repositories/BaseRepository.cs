using System.Data;
using System.Data.SqlClient;
using Sitetree.Core.Helpers;

namespace Sitetree.Core.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IDbConnection _db = new SqlConnection(SitetreeConfiguration.ConnectionString);
    }
}