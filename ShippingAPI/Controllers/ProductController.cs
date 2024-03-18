using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ShippingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    
    private readonly IProductServiceAsync _productServiceAsync;

    public ProductController(IProductServiceAsync productServiceAsync)
    {
        _productServiceAsync = productServiceAsync;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productServiceAsync.GetAllProductsAsync();

        if (!products.Any())
        {
            return NotFound(new { errorMessage = "No Products Found" }); 
        }

        return Ok(products);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productServiceAsync.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound(new { errorMessage = "No Product Found for id: " + id });
        }
        return Ok(product);
    }

    [HttpGet]
    [Route("{categoryName}")]
    public async Task<IActionResult> Category(string categoryName, int pageSize = 30, int pageNumber = 1)
    {
        var pagedProducts = await _productServiceAsync.GetProductsByCategoryAsync(categoryName, pageSize, pageNumber);
        
        return Ok(pagedProducts);
    }
}