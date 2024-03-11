using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class CategoryVariationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}