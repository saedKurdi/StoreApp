using Microsoft.EntityFrameworkCore;
using StoreApp.ProductService.Data;
using StoreApp.ProductService.Entities;
using StoreApp.ProductService.Repository.Abstract;

namespace StoreApp.ProductService.Repository.Concrete;
public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        // sending request to log service and log the info : 
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();
        var msg = await httpClient.GetAsync($"https://localhost:10605/api/log/{$"The Product {product.Name}-${product.Price} was added to db at {DateTime.UtcNow.ToShortDateString()} - {DateTime.UtcNow.ToLongTimeString()}"}");
        Console.WriteLine(msg + "- was sucessfully logged by log microservice .");
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task UpdateProductAsync(Product product)
    {
        return Task.Run(() =>
        {
            _context.Products.Update(product);
        });
    }
}
