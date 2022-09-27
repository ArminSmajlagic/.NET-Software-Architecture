using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.domain.entities;

namespace user.application.contracts.persistence
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> Insert(User entity);
        Task<User> Remove(int id);
        Task<User> Update(User entity);
    }
}
