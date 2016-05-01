using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Sitetree.DataAccess.Models;

namespace Sitetree.DataAccess.Repositories
{
    public class PageRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<Page> GetAll()
        {
            return _db.Query<Page>("SELECT * FROM Pages").ToList();
        }
    }
}
