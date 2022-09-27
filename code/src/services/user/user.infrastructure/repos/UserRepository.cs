using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.application.contracts.persistence;
using user.domain.entities;
using user.infrastructure.persistence;

namespace user.infrastructure.repos
{
    public class UserRepository: IUserRepository
    {
        private readonly ILogger<UserRepository> logger;
        private readonly UsersContext context;
        private readonly WalletContext wallet_Context;

        public UserRepository(ILogger<UserRepository> logger,UsersContext context, WalletContext wallet_context)
        {
            this.logger = logger;
            this.context = context;
            wallet_Context = wallet_context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await context.GetUsers();

            if (result == null)
                return null;

            return result;
        }

        public async Task<User> GetById(int id)
        {
            var result = await context.GetUser(id);

            if (result == null)
                return null;

            return result;
        }

        public async Task<User> GetByUsername(string username)
        {
            var result = await context.GetUser(username);

            if (result == null) 
                return null;

            return result;
        }

        public async Task<User> Insert(User entity)
        {
            var wallet = await wallet_Context.InsertWallet(new Wallet() { 
                card_name = "not set",
                card_number = "not set",
                cvv = "not set",
                expiration = "not set"
            });

            entity.wallet_id = wallet.id;

            var result = await context.InsertUser(entity);

            if (result == null)
                return null;

            return result;
        }

        public async Task<User> Remove(int id)
        {
            var result = await context.DeleteUser(id);

            if (result == null)
                return null;

            return result;
        }

        public async Task<User> Update(User entity)
        {
            var result = await context.UpdateUser(entity);

            if (result == null)
                return null;

            return result;
        }
    }
}
