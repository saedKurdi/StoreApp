using StoreApp.ProductService.Entities;

namespace StoreApp.ProductService.Repository.Abstract;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
}
