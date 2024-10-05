using StoreApp.SearchServiceAPI.Entities;

namespace StoreApp.SearchServiceAPI.Repository.Abstract;
public interface ISearchRepository
{
    Task<Barcode> GetAsync(string code);
}
