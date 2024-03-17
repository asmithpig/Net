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
}