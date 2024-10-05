using Microsoft.EntityFrameworkCore;
using StoreApp.BarcodeServiceAPI.Data;
using StoreApp.BarcodeServiceAPI.DTOS;
using StoreApp.BarcodeServiceAPI.Entities;
using StoreApp.BarcodeServiceAPI.Repository.Abstract;

namespace StoreApp.BarcodeServiceAPI.Repository.Concrete;
public class BarcodeRepository : IBarcodeRepository
{
    private readonly BarcodeDBContext _context;

    public BarcodeRepository(BarcodeDBContext context)
    {
        _context = context;
    }

    public async Task<string> AddBarcodeAsync(ProductItemDTO dto)
    {
        var item = await _context.Barcodes.FirstOrDefaultAsync(b => b.ProductId == dto.ProductId && b.Volume == dto.Volume);
        if (item == null)
        {
            var data = new Barcode
            {
                Code = $"4-12345:{dto.ProductId}-{dto.Volume}",
                ProductName = dto.ProductName ,
                ProductId = dto.ProductId ,
                Volume = dto.Volume ,
                TotalPrice = dto.Volume * dto.Price,
            };
            await _context.Barcodes.AddAsync(data);
            await _context.SaveChangesAsync();
            return data.Code;
        }
        return item.Code ?? "";
    }
}
