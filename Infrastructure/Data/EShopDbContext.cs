using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class EShopDbContext: DbContext
{
    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Shipper> Shippers { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Category> Categories { get; set; }
}