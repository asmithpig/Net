using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class ProductVariationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}