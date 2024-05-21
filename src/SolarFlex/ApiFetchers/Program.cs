using ApiFetchers.Data;
using ApiFetchers.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, configBuilder) =>
    {
        configBuilder.
            AddJsonFile("local.settings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables()
            .AddEnvironmentVariables();
    })
    .ConfigureServices((context,services) =>
    {

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<IDataBaseService, DataBaseService>();
        
        
        services.AddHttpClient<ISolarPowerService, SolarPowerService>("SolarPowerFetcher", client =>
        {
            client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("SolarPowerFetcher:BASE_URL") ?? "");
        });
        
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseNpgsql(Environment.GetEnvironmentVariable("SolarFlexDB"));
        });
    })
    .Build();

host.Run();
