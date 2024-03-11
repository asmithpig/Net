using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class ShoppingCartController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}