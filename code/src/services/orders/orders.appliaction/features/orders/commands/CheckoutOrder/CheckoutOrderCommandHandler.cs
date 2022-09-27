using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using orders.appliaction.contracts.infrastructure;
using orders.appliaction.contracts.persistance;
using orders.domain.entities;

namespace orders.appliaction.features.orders.commands.CheckoutOrder
{
    internal class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository reposiotry;
        private readonly ILogger<CheckoutOrderCommandHandler> logger;
        private readonly IEmailService emailService;

        public CheckoutOrderCommandHandler(IMapper mapper, IOrderRepository reposiotry, ILogger<CheckoutOrderCommandHandler> logger,IEmailService emailService)
        {
            this.mapper = mapper;
            this.reposiotry = reposiotry;
            this.logger = logger;
            this.emailService = emailService;
        }
        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Order>(request);

            var result = await reposiotry.Insert(entity);


            if (result != null)
            {
                //await emailService.SendEmail(new models.Email() { });

                logger.LogInformation($"Order with id: {result.id} is successfully created!");
                return result.id;
            }

            logger.LogInformation($"Order was not created!");


            return 0;
        }
    }
}
