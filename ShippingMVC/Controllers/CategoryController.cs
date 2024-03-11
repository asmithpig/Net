using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}