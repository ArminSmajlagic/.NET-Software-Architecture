using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using orders.appliaction.contracts.infrastructure;
using orders.appliaction.contracts.persistance;
using orders.appliaction.models;
using orders.infrastructure.email;
using orders.infrastructure.persistence;
using orders.infrastructure.repos;

namespace orders.infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) {

            services.AddScoped<OrdersContext>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();


            services.Configure<EmailSettings>(c=>configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService,EmailService>();

            return services;
        }
    }
}
