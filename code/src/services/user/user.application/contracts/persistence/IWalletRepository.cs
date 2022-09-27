using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.domain.entities;

namespace user.application.contracts.persistence
{
    public interface IWalletRepository
    {
        Task<Wallet> GetById(int id);
        Task<IEnumerable<Wallet>> GetAll();
        Task<Wallet> Insert(Wallet entity);
        Task<Wallet> Remove(int id);
        Task<Wallet> Update(Wallet entity);
    }
}
