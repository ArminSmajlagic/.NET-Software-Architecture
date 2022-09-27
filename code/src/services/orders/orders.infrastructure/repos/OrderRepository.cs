using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using orders.appliaction.contracts.persistance;
using orders.domain.entities;
using orders.infrastructure.persistence;

namespace orders.infrastructure.repos
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly OrdersContext context;
        private readonly ILogger<BaseRepository<Order>> logger;

        public OrderRepository(OrdersContext context, ILogger<BaseRepository<Order>> logger) : base(context, logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<IEnumerable<Order>> GetOrderByUsername(string username)
        {
            var result = await context.orders.Where(x => x.username.ToLower() == username.ToLower()).ToListAsync();

            return result;
        }

        public override async Task<Order> Update(Order entity)
        {
           var resultEntity = await context.orders.FirstOrDefaultAsync(x=>x.id == entity.id);

           if (resultEntity.username!=entity.username && !string.IsNullOrEmpty(entity.username))
                resultEntity.username = entity.username;

            if (resultEntity.total_price != entity.total_price && entity.total_price != 0)
                resultEntity.total_price = entity.total_price;

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
