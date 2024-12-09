using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Infraestructure.Persistence.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection()
                {
                    ConnectionString = _configuration.GetConnectionString("ConnectionBase")
                };
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
