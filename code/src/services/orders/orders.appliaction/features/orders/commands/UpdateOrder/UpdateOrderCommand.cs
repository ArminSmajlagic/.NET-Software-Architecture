using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.features.orders.commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int id { get; set; }
        public string username { get; set; }
        public decimal total_price { get; set; }
        public int user_id { get; set; }
        public int payment_id { get; set; }
    }
}
