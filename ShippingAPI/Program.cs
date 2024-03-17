using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EShopDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("EShopDBConnection"));
});

builder.Services.AddScoped<ICustomerRepositoryAsyncAsync, CustomerRepositoryAsyncAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();

builder.Services.AddScoped<IShipperRepositoryAsync, ShipperRepositoryAsync>();
builder.Services.AddScoped<IShipperServiceAsync, ShipperServiceAsync>();

builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();

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