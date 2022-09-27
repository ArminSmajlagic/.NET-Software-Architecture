using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;
using user.domain.entities;
using user.infrastructure.persistence;

namespace user.infrastructure.repos
{
    public class WalletRepository: IWalletRepository
    {
        private readonly ILogger<WalletRepository> logger;
        private readonly WalletContext context;

        public WalletRepository(ILogger<WalletRepository> logger, WalletContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IEnumerable<Wallet>> GetAll()
        {
            var result = await context.GetWallets();

            if (result == null)
                return null;

            return result;
        }

        public async Task<Wallet> GetById(int id)
        {
            var result = await context.GetWallet(id);

            if (result == null)
                return null;

            return result;
        }

        public async Task<Wallet> Insert(Wallet entity)
        {
            var result = await context.InsertWallet(entity);

            if (result == null)
                return null;

            return result;
        }

        public async Task<Wallet> Remove(int id)
        {
            var result = await context.DeleteWallet(id);

            if (result == null)
                return null;

            return result;
        }

        public async Task<Wallet> Update(Wallet entity)
        {
            var result = await context.UpdateWallet(entity);

            if (result == null)
                return null;

            return result;
        }
    }
}
