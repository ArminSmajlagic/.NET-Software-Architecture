using EventBus.Messages.Common;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using orders.appliaction.behaviours;
using orders.appliaction.mappings;
using orders.appliaction.RabbitMQ;
using System.Reflection;

namespace orders.appliaction
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMassTransit(config =>
            {
                config.AddConsumer<BasketCheckoutConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQSettings:Host"]);
                    cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
                    {
                        c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
                    });
                });
            });

            services.AddScoped<BasketCheckoutConsumer>();

            services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>),typeof(UnhandeledExceptionBehavior<,>));

            return services;
        }
    }
}
