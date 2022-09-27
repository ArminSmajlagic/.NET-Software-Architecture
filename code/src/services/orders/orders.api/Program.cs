using orders.api.Logging;
using orders.appliaction;
using orders.infrastructure;
using orders.infrastructure.persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//configure logging
LoggingConfiguration.ConfigureLogging();
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrdersContext>();
    var logger = services.GetRequiredService<ILogger<OrdersContextSeed>>();

    context.Database.EnsureCreated();

    OrdersContextSeed.SeedData(context, logger);

}

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
