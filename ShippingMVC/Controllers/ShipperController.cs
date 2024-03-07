using Microsoft.AspNetCore.Mvc;
using ShippingMVC.Models;

namespace ShippingMVC.Controllers;

public class ShipperController : Controller
{
    List<Shipper> shippers = new List<Shipper>();
    
    public ShipperController()
    {
        shippers.Add(new Shipper() { Id = 1, Name = "Tom", Address = "CA", Contact = "123456" });
        shippers.Add(new Shipper() { Id = 2, Name = "Jerry", Address = "CO", Contact = "223456" });
        shippers.Add(new Shipper() { Id = 3, Name = "Tim", Address = "TX", Contact = "323456" });
        shippers.Add(new Shipper() { Id = 4, Name = "Ben", Address = "NY", Contact = "423456" });
    }

    // GET
    public IActionResult Index()
    {
        return View(shippers);
    }
}