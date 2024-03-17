using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class ProductController : Controller
{

    private readonly IProductServiceAsync _productServiceAsync;

    public ProductController(IProductServiceAsync productServiceAsync)
    {
        _productServiceAsync = productServiceAsync;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _productServiceAsync.GetAllProductsAsync();
        
        return View(result);
    }

    public async Task<IActionResult> Category(string categoryName, int pageSize = 30, int pageNumber = 1)
    {
        var pagedProducts = await _productServiceAsync.GetProductsByCategoryAsync(categoryName, pageSize, pageNumber);

        ViewData["categoryName"] = categoryName;
        
        return View("PagedProducts", pagedProducts);
    }
}