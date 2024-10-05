using Microsoft.EntityFrameworkCore;
using StoreApp.BarcodeServiceAPI.Entities;

namespace StoreApp.BarcodeServiceAPI.Data;
public class BarcodeDBContext : DbContext
{
    public BarcodeDBContext(DbContextOptions<BarcodeDBContext> options) : base(options) { }

    // tables : 
    public DbSet<Barcode> Barcodes { get; set; }
}
