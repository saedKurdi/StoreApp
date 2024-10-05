using StoreApp.BarcodeServiceAPI.DTOS;

namespace StoreApp.BarcodeServiceAPI.Repository.Abstract;
public interface IBarcodeRepository
{
    Task<string> AddBarcodeAsync(ProductItemDTO dto);
}
