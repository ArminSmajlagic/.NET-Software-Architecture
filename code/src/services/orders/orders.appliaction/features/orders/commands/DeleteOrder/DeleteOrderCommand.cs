using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.features.orders.commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int id { get; set; }
    }
}
