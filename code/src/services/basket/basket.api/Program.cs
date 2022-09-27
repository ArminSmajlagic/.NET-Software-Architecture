using basket.api.IRepos;
using basket.api.Logging;
using basket.api.Mapping;
using basket.api.Repos;
using MassTransit;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

LoggingConfiguration.ConfigureLogging();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddStackExchangeRedisCache( options=>
        options.Configuration = builder.Configuration.GetValue<string>("RedisSettings:ConnectionConfiguration")
);

builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx,cfg) => {
        cfg.Host(builder.Configuration["RabbitMqSettings:Host"]);
        //cfg.UseHealthChecks(ctx);
    });
});

//builder.Services.AddMassTransitHostedService();

builder.Services.AddTransient<IBasketRepository, BasketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
