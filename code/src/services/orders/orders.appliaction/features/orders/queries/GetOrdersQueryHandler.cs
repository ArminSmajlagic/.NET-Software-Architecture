using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using orders.appliaction.contracts.persistance;
using orders.appliaction.models.OrderVM;
using orders.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.features.orders.queries
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrdersVM>>
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository reposiotry;
        private readonly ILogger<GetOrdersQueryHandler> logger;

        public GetOrdersQueryHandler(IMapper mapper, IOrderRepository reposiotry, ILogger<GetOrdersQueryHandler> logger)
        {
            this.mapper = mapper;
            this.reposiotry = reposiotry;
            this.logger = logger;
        }
        public async Task<List<OrdersVM>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Username))
            {
                var result = (await reposiotry.GetAll()).ToList();

                var mappedResult = mapper.Map<List<OrdersVM>>(result);

                return mappedResult;
            }
            else
            {
                var result = (await reposiotry.GetOrderByUsername(request.Username)).ToList();

                var mappedResult = mapper.Map<List<OrdersVM>>(result);

                return mappedResult;

                return mappedResult;
            }


            return null;
        }
    }
}
