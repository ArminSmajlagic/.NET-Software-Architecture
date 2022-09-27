using EventBus.Messages.Events;
using MassTransit;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using orders.appliaction.features.orders.commands.CheckoutOrder;

namespace orders.appliaction.RabbitMQ
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly ILogger<BasketCheckoutConsumer> logger;

        public BasketCheckoutConsumer(IMapper mapper, IMediator mediator, ILogger<BasketCheckoutConsumer> logger)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.logger = logger;
        }
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var mappedEventMessage = mapper.Map<CheckoutOrderCommand>(context.Message);

            var result = await mediator.Send(mappedEventMessage);

            logger.LogInformation($"New order has been created using {nameof(BasketCheckoutConsumer)}, with order id: {result}.",DateTime.Now);

        }
    }
}