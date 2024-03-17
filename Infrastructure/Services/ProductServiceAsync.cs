using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services;

public class ProductServiceAsync : IProductServiceAsync
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;

    public ProductServiceAsync(IProductRepositoryAsync productRepositoryAsync)
    {
        _productRepositoryAsync = productRepositoryAsync;
    }

    public async Task<ProductResponseModel> GetProductByIdAsync(int id)
    {
        var result = await _productRepositoryAsync.GetByIdAsync(id);

        return new ProductResponseModel()
        {
            Id = result.Id,
            ProductName = result.ProductName,
            UnitPrice = result.UnitPrice,
            ImageUrl = result.ImageUrl
        };
    }

    public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
    {
        var result = await _productRepositoryAsync.GetAllAsync();

        return result.Select(x => new ProductResponseModel()
        {
            Id = x.Id,
            ProductName = x.ProductName,
            UnitPrice = x.UnitPrice,
            ImageUrl = x.ImageUrl
        });
    }

    public Task<int> AddProductAsync(ProductRequestModel model)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateProductAsync(ProductRequestModel model)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResultSetModel<ProductResponseModel>> GetProductsByCategoryAsync(string categoryName, int pageSize, int pageNumber)
    {
        var products = await _productRepositoryAsync.GetProductsByCategoryAsync(categoryName, pageSize, pageNumber);
        var productResponse = new List<ProductResponseModel>();

        foreach (var product in products.PagedData)
        {
            productResponse.Add(new ProductResponseModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                ImageUrl = product.ImageUrl
            });
        }

        return new PagedResultSetModel<ProductResponseModel>(pageNumber, products.TotalRecords, pageSize, productResponse);
    }
}