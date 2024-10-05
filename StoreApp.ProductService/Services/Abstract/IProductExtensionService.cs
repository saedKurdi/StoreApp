namespace StoreApp.ProductService.Services.Abstract;
public interface IProductExtensionService
{
    Task<string> GetProductImageAsync(int productId);
}
