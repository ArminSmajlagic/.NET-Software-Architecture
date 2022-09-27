using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using orders.appliaction.contracts.infrastructure;
using orders.appliaction.contracts.persistance;
using orders.domain.entities;

namespace orders.appliaction.features.orders.commands.UpdateOrder
{
    internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository reposiotry;
        private readonly ILogger<UpdateOrderCommandHandler> logger;

        public UpdateOrderCommandHandler(IMapper mapper, IOrderRepository reposiotry, ILogger<UpdateOrderCommandHandler> logger)
        {
            this.mapper = mapper;
            this.reposiotry = reposiotry;
            this.logger = logger;
        }
        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var checkOrder = await reposiotry.GetOrderByUsername(request.username) == null;

            if(checkOrder)
            {
                logger.LogInformation($"Order does not exist!");

                return 0;
            }

            var entity = mapper.Map<Order>(request);

            var result = await reposiotry.Update(entity);

            if (result != null)
            {
                logger.LogInformation($"Order with id: {result.id} is successfully updated!");

                return result.id;
            }

            logger.LogInformation($"Order was not updated!");

            return 0;
        }
    }
}
