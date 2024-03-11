using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class OrderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}