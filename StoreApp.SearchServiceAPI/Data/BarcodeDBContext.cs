using Microsoft.EntityFrameworkCore;
using StoreApp.SearchServiceAPI.Entities;

namespace StoreApp.SearchServiceAPI.Data;
public class BarcodeDBContext:DbContext
{
    public BarcodeDBContext(DbContextOptions<BarcodeDBContext> options) : base(options) { }

    // tables : 
    public DbSet<Barcode> Barcodes { get; set; }
}
