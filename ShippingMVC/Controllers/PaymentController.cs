using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class PaymentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}