using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Sitetree.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IDbConnection _db =
            new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
}