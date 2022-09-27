using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.contracts.persistance
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T,bool>> predicate);
        Task<T> Update(T entity);
        Task<T> Insert(T entity);
        Task<T> Delete(int id);




    }
}
