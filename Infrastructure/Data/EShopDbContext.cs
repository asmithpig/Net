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
}