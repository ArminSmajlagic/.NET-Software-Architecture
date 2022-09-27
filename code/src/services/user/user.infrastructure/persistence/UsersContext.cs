using Dapper;
using Microsoft.Extensions.Logging;
using user.domain.entities;

namespace user.infrastructure.persistence
{
    public class UsersContext
    {
        private readonly ILogger<UsersContext> logger;
        private readonly Database database;

        public UsersContext(ILogger<UsersContext> logger, Database database)
        {
            this.logger = logger;
            this.database = database;
        }


        public async Task<User> GetUser(int id)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "SELECT * FROM users WHERE id = @id";

                var parameters = new DynamicParameters();

                parameters.Add("id", id);

                var user = await connection.QueryFirstOrDefaultAsync<User>(query,parameters);

                if(user == null)
                    return null;

                return user;
            }
        }

        public async Task<User> GetUser(string username)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "SELECT * FROM users WHERE username = @username";

                var parameters = new DynamicParameters();

                parameters.Add("username", username);

                var user = await connection.QueryFirstOrDefaultAsync<User>(query, parameters);

                if (user == null)
                    return null;

                return user;
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using (var connection = database.CreateConnection())
            {
                var query = "SELECT * FROM users";

                var user = await connection.QueryAsync<User>(query);

                if (user == null)
                    return null;

                return user;
            }
        }

        public async Task<User> InsertUser(User entity)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "INSERT INTO users " +
                    "(created_by, created, modified_by,modifed,username,password,first_name,last_name,country,zip_code,wallet_id) " +
                    "VALUES " +
                    "(@created_by, @created, @modified_by,@modifed,@username,@password,@first_name,@last_name,@country,@zip_code,@wallet_id)";

                var parameters = new DynamicParameters();

                parameters.Add("username", entity.username);
                parameters.Add("created", DateTime.Now);
                parameters.Add("created_by", "user.api.user");
                parameters.Add("modified_by", "not modified");
                parameters.Add("modifed", DateTime.MinValue);
                parameters.Add("password", entity.password);
                parameters.Add("first_name", entity.first_name);
                parameters.Add("last_name", entity.last_name);
                parameters.Add("country", entity.country);
                parameters.Add("zip_code", entity.zip_code);
                parameters.Add("wallet_id", entity.wallet_id);

                var respons = await connection.ExecuteAsync(query, parameters);

                if (respons == 0)
                    return null;

                return entity;
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "DELETE FROM users WHERE id = @id";

                var parameters = new DynamicParameters();

                parameters.Add("id", id);

                var user = await connection.ExecuteAsync(query, parameters);

                if (user == null)
                    return null;

                var entity = await GetUser(id);

                return entity;
            }
        }

        public async Task<User> UpdateUser(User entity)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "UPDATE users SET modified_by=@modified_by, modifed=@modifed";

                var parameters = new DynamicParameters();

                parameters.Add("modified_by", "user.api.user");

                parameters.Add("modifed", DateTime.Now);

                if (!string.IsNullOrEmpty(entity.username))
                {
                    parameters.Add("username", entity.username);
                    query += ",username=@username";
                }
                if (!string.IsNullOrEmpty(entity.password))
                {
                    parameters.Add("password", entity.password);
                    query += ",password=@password";
                }
                if (!string.IsNullOrEmpty(entity.first_name))
                {
                    parameters.Add("first_name", entity.first_name);
                    query += ",first_name=@first_name";
                }
                if (!string.IsNullOrEmpty(entity.zip_code))
                {
                    parameters.Add("zip_code", entity.zip_code);
                    query += ",zip_code=@zip_code";
                }
                if (!string.IsNullOrEmpty(entity.last_name))
                {
                    parameters.Add("last_name", entity.last_name);
                    query += ",last_name=@last_name";
                }
                if (!string.IsNullOrEmpty(entity.country))
                {
                    parameters.Add("country", entity.country);
                    query += ",country=@country";
                }

                query += " WHERE id=@id";

                parameters.Add("id",entity.id);

                var respons = await connection.ExecuteAsync(query, parameters);

                if (respons == 0)
                    return null;

                return entity;
            }
        }

    }
}
