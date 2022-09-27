using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using orders.appliaction.contracts.persistance;
using orders.domain.common;
using orders.infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace orders.infrastructure.repos
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly OrdersContext context;
        private readonly ILogger<BaseRepository<T>> logger;

        public BaseRepository(OrdersContext context,ILogger<BaseRepository<T>> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<T> Delete(int id)
        {
            var entity = await GetById(id);

            var result = context.Set<T>().Remove(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await context.Set<T>().ToListAsync();

            return result;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            var result = await context.Set<T>().Where(predicate).ToListAsync();

            return result;
        }

        public async Task<T> GetById(int id)
        {
            var result = await context.Set<T>().FindAsync(id);

            return result;
        }

        public async Task<T> Insert(T entity)
        {
            var result = await context.Set<T>().AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            var result = context.Set<T>().Update(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
