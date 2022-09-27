using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using orders.appliaction.contracts.infrastructure;
using orders.appliaction.contracts.persistance;


namespace orders.appliaction.features.orders.commands.DeleteOrder
{
    internal class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository reposiotry;
        private readonly ILogger<DeleteOrderCommandHandler> logger;

        public DeleteOrderCommandHandler(IMapper mapper, IOrderRepository reposiotry, ILogger<DeleteOrderCommandHandler> logger)
        {
            this.mapper = mapper;
            this.reposiotry = reposiotry;
            this.logger = logger;
        }
        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await reposiotry.GetById(request.id);

            if (order == null)
            {
                logger.LogInformation($"Order does not exist!");

                return 0;
            }

            var result = await reposiotry.Delete(order.id);

            if(result == null)
            {
                logger.LogInformation($"Order was not deleted!");

                return 0;
            }

            logger.LogInformation($"Order with id: {order.id} is successfully deleted!");

            return order.id;
        }
    }
}
