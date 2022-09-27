using FluentMigrator.Runner;
using Serilog;
using user.application;
using user.infrastructure;
using user.infrastructure.persistence;
using users.api.Logging;

var builder = WebApplication.CreateBuilder(args);

//configure logging
LoggingConfiguration.ConfigureLogging();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
    var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    //var loggerService = scope.ServiceProvider.GetRequiredService<ILogger>();
    try
    {
        //databaseService.CreateDatabase("UserDb");
        migrationService.ListMigrations();
        migrationService.MigrateUp();
    }
    catch(Exception ex)
    {
        //loggerService.LogError("Database could not be created and migrated :(");
        throw ex;
    }
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
