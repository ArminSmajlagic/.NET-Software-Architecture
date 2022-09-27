using Microsoft.Extensions.Logging;
using orders.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.infrastructure.persistence
{
    public class OrdersContextSeed
    {
        public static void SeedData(OrdersContext ordersContext,ILogger<OrdersContextSeed> logger)
        {
            if (!ordersContext.orders.Any())
            {
                ordersContext.orders.AddRange(Data());

                ordersContext.SaveChanges();

                logger.LogInformation("Data was successfully seeded!");
            }
        }

        private static Order[] Data()
        {
            return new Order[] {
                new Order(){
                    payment_id=1,
                    user_id=1,
                    total_price=100,
                    username="User 1"
                },
                new Order(){
                    payment_id=2,
                    user_id=2,
                    total_price=200,
                    username="User 2"
                },
                new Order(){
                    payment_id=3,
                    user_id=3,
                    total_price=300,
                    username="User 3"
                },
            };
        }
    }
}
