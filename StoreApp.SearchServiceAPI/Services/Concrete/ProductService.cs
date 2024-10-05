using StoreApp.SearchServiceAPI.Services.Abstract;

namespace StoreApp.SearchServiceAPI.Services.Concrete;
public class ProductService : IProductService
{
    public string ImageUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<string> GetProductImagePathAsync(int productId)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        string url = $"https://localhost:10601/api/product/image/{productId}";
        httpResponse = await httpClient.GetAsync(url);
        var str = await httpResponse.Content.ReadAsStringAsync();
        return str;
    }
}
