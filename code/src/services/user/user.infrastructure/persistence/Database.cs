using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;

namespace user.infrastructure.persistence
{
    public class Database
    {
        private readonly IConfiguration configuration;

        public Database(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection CreateConnection()
         => new NpgsqlConnection(configuration.GetConnectionString("usersdb"));
        public void CreateDatabase(string dbName)
        {
            var query = "SELECT * FROM sys.databases WHERE name = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using (var connection = CreateConnection())
            {
                var records = connection.Query(query,parameters);
                if (!records.Any())
                {
                    connection.Execute($"CREATE DATABASE {dbName}");
                }
            }
        }
    }
}
