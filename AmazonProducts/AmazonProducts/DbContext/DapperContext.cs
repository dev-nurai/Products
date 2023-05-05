using Microsoft.Data.SqlClient;
using System.Data;

namespace AmazonProducts.DbContext
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
            var connectionString = _configuration.GetConnectionString("AmazonDb");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
