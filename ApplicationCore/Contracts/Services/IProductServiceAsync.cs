using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface IProductServiceAsync
{
    Task<ProductResponseModel> GetProductByIdAsync(int id);
    
    Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
    
    Task<int> AddProductAsync(ProductRequestModel model);
    
    Task<int> UpdateProductAsync(ProductRequestModel model);
    
    Task<int> DeleteProductAsync(int id);
    Task<PagedResultSetModel<ProductResponseModel>> GetProductsByCategoryAsync(string categoryName, int pageSize, int pageNumber);
}