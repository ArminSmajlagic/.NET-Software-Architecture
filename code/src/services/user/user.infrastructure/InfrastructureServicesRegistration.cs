using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using user.infrastructure.persistence;
using FluentMigrator;
using FluentMigrator.Runner;
using System.Reflection;
using user.application.contracts.persistence;
using user.infrastructure.repos;

namespace user.infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton<Database>();
            services.AddSingleton<UsersContext>();
            services.AddSingleton<WalletContext>();

            services.AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddPostgres11_0()
                .WithGlobalConnectionString(configuration.GetConnectionString("usersdb"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();

            return services;
        }
    }
}
