using MediatR;
using orders.appliaction.models.OrderVM;
using orders.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.features.orders.queries
{
    public class GetOrdersQuery : IRequest<List<OrdersVM>>
    {
        public GetOrdersQuery(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
