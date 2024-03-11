using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class PromotionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}