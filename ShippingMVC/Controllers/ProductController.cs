using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}