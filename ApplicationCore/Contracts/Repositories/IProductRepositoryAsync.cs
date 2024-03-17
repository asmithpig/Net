using ApplicationCore.Entities;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Repositories;

public interface IProductRepositoryAsync : IRepositoryAsync<Product>
{
    Task<PagedResultSetModel<Product>> GetProductsByCategoryAsync(string categoryName, int pageSize, int pageNumber);
}