namespace StoreApp.SearchServiceAPI.Services.Abstract;
public interface IProductService
{
    string ImageUrl { get; set; }
    Task<string> GetProductImagePathAsync(int productId);
}
