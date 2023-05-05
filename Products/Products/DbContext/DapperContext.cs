using Microsoft.Data.SqlClient;
using System.Data;

namespace Products.DbContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("ProductsDb");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
