using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// For running ocelot.Local.json set "ASPNETCORE_ENVIRONMENT": "Local" in launchSettings.json
// For running ocelot.Development.json it will be read from the docker environment gateway.api settings
// For running ocelot.ServiceDiscovery.json locally set "ASPNETCORE_ENVIRONMENT": "ServiceDiscoveryLocal" in launchSettings.json
// For running ocelot.ServiceDiscovery.json locally set "ASPNETCORE_ENVIRONMENT": "ServiceDiscoveryDocker" in ironment gateway.api settings

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);


builder.Services.AddOcelot()
                .AddCacheManager(settings => settings.WithDictionaryHandle())
                .AddConsul(); // Adding consul service discovey to ocelot gateway 

//.AddDelegatingHandler<DownstreamUrlHandler>(true);
builder.Logging.ClearProviders()
               .AddConsole()
               .AddDebug();


builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.UseOcelot();

app.Run();
