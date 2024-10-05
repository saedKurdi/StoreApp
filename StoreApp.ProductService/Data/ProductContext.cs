using Microsoft.EntityFrameworkCore;
using StoreApp.ProductService.Entities;

namespace StoreApp.ProductService.Data;
public class ProductContext : DbContext
{
    // parametric constructor for injecting from 'program.cs' : 
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

    // tables in db : 
    public DbSet<Product> Products { get; set; }
}
