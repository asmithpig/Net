using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
{
    public ProductRepositoryAsync(EShopDbContext context) : base(context)
    {
    }

    public async Task<PagedResultSetModel<Product>> GetProductsByCategoryAsync(string categoryName, int pageSize, int pageNumber)
    {
        var query = _context.Products.Where(p => p.Category.Name == categoryName);
        int totalProductsForCategory = await query.CountAsync();
        var products = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResultSetModel<Product>(pageNumber, totalProductsForCategory, pageSize, products);
    }
}