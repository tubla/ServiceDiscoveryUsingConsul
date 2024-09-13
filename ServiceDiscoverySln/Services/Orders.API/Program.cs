using Orders.API.Repositories;
using ServiceDiscovery.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IOrderRepository, OrderRepository>();


// Register orders.api service details to consul service discovery
builder.Services.RegisterConsulServices(builder.Configuration.GetServiceDetailsConfiguration());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ********************** IMPORTANT *****************************************

// If this is not commented then ocelot gateway downstreampath will not be able to connect to the api
// as ocelot is configured with http scheme for accessing apis.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
