using Microsoft.EntityFrameworkCore;
using StoreApp.SearchServiceAPI.Data;
using StoreApp.SearchServiceAPI.Entities;
using StoreApp.SearchServiceAPI.Repository.Abstract;

namespace StoreApp.SearchServiceAPI.Repository.Concrete;
public class SearchRepository : ISearchRepository
{
    private readonly BarcodeDBContext _context;

    public SearchRepository(BarcodeDBContext context)
    {
        _context = context;
    }

    public async Task<Barcode> GetAsync(string code)
    {
        return await _context.Barcodes.SingleOrDefaultAsync(b => b.Code == code);
    }
}
