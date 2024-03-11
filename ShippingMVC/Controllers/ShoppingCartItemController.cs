using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class ShoppingCartItemController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}