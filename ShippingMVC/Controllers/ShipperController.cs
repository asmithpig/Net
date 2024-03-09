using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
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
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShipperRequestModel model)
    {
        if (ModelState.IsValid)
        {
            await _shipperService.AddShipper(model);

            return RedirectToAction("Index");
        }

        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

        var result = await _shipperService.GetShipperById(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ShipperRequestModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _shipperService.UpdateShipper(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(new ShipperResponseModel()
                {
                    Id = model.Id,
                    CompanyName = model.CompanyName,
                    Mobile = model.Mobile
                });
            }
        }
        
        return View(new ShipperResponseModel()
        {
            Id = model.Id,
            CompanyName = model.CompanyName,
            Mobile = model.Mobile
        });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {

        var result = await _shipperService.GetShipperById(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ShipperRequestModel model)
    {
        await _shipperService.DeleteShipper(model.Id);

        return RedirectToAction("Index");
    }
}