using Dapper;
using Microsoft.Extensions.Logging;
using user.domain.entities;

namespace user.infrastructure.persistence
{
    public class WalletContext
    {
        private readonly Database database;
        private readonly ILogger<WalletContext> logger;

        public WalletContext(Database database, ILogger<WalletContext> logger)
        {
            this.database = database;
            this.logger = logger;
        }

        public async Task<Wallet> GetWallet(int id)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "SELECT * FROM wallets WHERE id = @id";

                var parameters = new DynamicParameters();

                parameters.Add("id", id);

                var user = await connection.QueryFirstOrDefaultAsync<Wallet>(query, parameters);

                if (user == null)
                    return null;

                return user;
            }
        }

        public async Task<IEnumerable<Wallet>> GetWallets()
        {
            using (var connection = database.CreateConnection())
            {
                var query = "SELECT * FROM wallets";

                var user = await connection.QueryAsync<Wallet>(query);

                if (user == null)
                    return null;

                return user;
            }
        }

        public async Task<Wallet> InsertWallet(Wallet entity)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "INSERT INTO wallets " +
                    "(created_by, created, modified_by,modifed,expiration,card_name,card_number,cvv) " +
                    "VALUES " +
                    "(@created_by, @created, @modified_by,@modifed,@expiration,@card_name,@card_number,@cvv) RETURNING id";

                var parameters = new DynamicParameters();

                parameters.Add("created", DateTime.Now);
                parameters.Add("created_by", "user.api.wallet");
                parameters.Add("modified_by", "not modified");
                parameters.Add("modifed", DateTime.MinValue);
                parameters.Add("expiration", entity.expiration);
                parameters.Add("card_name", entity.card_name);
                parameters.Add("card_number", entity.card_number);
                parameters.Add("cvv", entity.cvv);
 
                var respons = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);

                if (respons == 0)
                    return null;

                var wallet = await GetWallet(respons);

                return wallet;
            }
        }

        public async Task<Wallet> DeleteWallet(int id)
        {
            using (var connection = database.CreateConnection())
            {
                var entity = await GetWallet(id);

                var query = "DELETE FROM wallets WHERE id = @id";

                var parameters = new DynamicParameters();

                parameters.Add("id", id);

                var user = await connection.ExecuteAsync(query, parameters);

                if (user == 0)
                    return null;

                return entity;
            }
        }

        public async Task<Wallet> UpdateWallet(Wallet entity)
        {
            using (var connection = database.CreateConnection())
            {
                var query = "UPDATE wallets SET modified_by=@modified_by, modifed=@modifed";

                var parameters = new DynamicParameters();

                parameters.Add("modified_by", "user.api.wallet");

                parameters.Add("modifed", DateTime.Now);

                if (!string.IsNullOrEmpty(entity.expiration))
                {
                    parameters.Add("expiration", entity.expiration);
                    query += ",expiration=@expiration";
                }
                if (!string.IsNullOrEmpty(entity.cvv))
                {
                    parameters.Add("cvv", entity.cvv);
                    query += ",cvv=@cvv";
                }
                if (!string.IsNullOrEmpty(entity.card_name))
                {
                    parameters.Add("card_name", entity.card_name);
                    query += ",card_name=@card_name";
                }
                if (!string.IsNullOrEmpty(entity.card_number))
                {
                    parameters.Add("card_number", entity.card_number);
                    query += ",card_number=@card_number";
                }
              
                query += " WHERE id=@id";

                parameters.Add("id", entity.id);

                var respons = await connection.ExecuteAsync(query, parameters);

                if (respons == 0)
                    return null;

                return entity;
            }
        }
    }
}
