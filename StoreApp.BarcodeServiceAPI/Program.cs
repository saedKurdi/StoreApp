using Microsoft.EntityFrameworkCore;
using StoreApp.BarcodeServiceAPI.Data;
using StoreApp.BarcodeServiceAPI.Repository.Abstract;
using StoreApp.BarcodeServiceAPI.Repository.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding custom ports : 
builder.WebHost.UseUrls("https://*:10602");

// adding db context injecting options :
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<BarcodeDBContext>(options =>
{
    options.UseSqlServer(connection);
});

// adding repository injection :
builder.Services.AddScoped<IBarcodeRepository, BarcodeRepository>();

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
