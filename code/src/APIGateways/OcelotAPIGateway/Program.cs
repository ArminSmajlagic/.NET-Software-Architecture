using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddJsonFile($"ocelot.{hostContext.HostingEnvironment.EnvironmentName}.json",true,true);
    })
    .ConfigureLogging((hostingContext, loggingBuilder) =>
    {
        loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        loggingBuilder.AddConsole();
        loggingBuilder.AddDebug();
    });

builder.Services.AddOcelot()
        .AddCacheManager(x=>
        x.WithDictionaryHandle()
    );

//builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

app.UseRouting();

// Swagger not suported
//app.UseSwaggerForOcelotUI(opt =>
//{
//    opt.PathToSwaggerGenerator = "/swagger/docs";
//});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});

await app.UseOcelot();

app.Run();

