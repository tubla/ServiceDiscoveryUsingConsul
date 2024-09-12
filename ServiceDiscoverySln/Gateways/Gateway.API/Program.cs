using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// For running ocelot.Local.json set "ASPNETCORE_ENVIRONMENT": "Local" in launchSettings.json 
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);
builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
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
