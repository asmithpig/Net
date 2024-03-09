using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class ShipperController : Controller
{

    private readonly IShipperService _shipperService;

    public ShipperController(IShipperService shipperService)
    {
        _shipperService = shipperService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _shipperService.GetAllShippers();

        return View(result);
    }
}