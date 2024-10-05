using Microsoft.EntityFrameworkCore;
using StoreApp.SearchServiceAPI.Data;
using StoreApp.SearchServiceAPI.Repository.Abstract;
using StoreApp.SearchServiceAPI.Repository.Concrete;
using StoreApp.SearchServiceAPI.Services.Abstract;
using StoreApp.SearchServiceAPI.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.WebHost.UseUrls("https://*:10603");

//
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<BarcodeDBContext>(options =>
{
    options.UseSqlServer(connection);
});

//
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();

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
