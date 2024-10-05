using Microsoft.EntityFrameworkCore;
using StoreApp.ProductService.Data;
using StoreApp.ProductService.Repository.Abstract;
using StoreApp.ProductService.Repository.Concrete;
using StoreApp.ProductService.Services.Abstract;
using StoreApp.ProductService.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding custom port : 
builder.WebHost.UseUrls("https://*:10601");

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// adding db context option injection :
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(connection);
});

// registering other injections :
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductExtensionService,ProductExtensionService>();


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
