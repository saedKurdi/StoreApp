using StoreApp.ProductService.Repository.Abstract;
using StoreApp.ProductService.Services.Abstract;

namespace StoreApp.ProductService.Services.Concrete;
public class ProductExtensionService : IProductExtensionService
{
    private readonly IProductRepository _productRepository;

    public ProductExtensionService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<string> GetProductImageAsync(int productId)
    {
        var item = await _productRepository.GetByIdAsync(productId);
        return item != null ? item.ImageUrl : "";
    }
}
