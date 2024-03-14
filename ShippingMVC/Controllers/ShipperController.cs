using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class ShipperController : Controller
{

    private readonly IShipperServiceAsync _shipperServiceAsync;

    public ShipperController(IShipperServiceAsync shipperServiceAsync)
    {
        _shipperServiceAsync = shipperServiceAsync;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _shipperServiceAsync.GetAllShippersAsync();

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
            await _shipperServiceAsync.AddShipperAsync(model);

            return RedirectToAction("Index");
        }

        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

        var result = await _shipperServiceAsync.GetShipperByIdAsync(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ShipperRequestModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _shipperServiceAsync.UpdateShipperAsync(model);

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

        var result = await _shipperServiceAsync.GetShipperByIdAsync(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ShipperRequestModel model)
    {
        await _shipperServiceAsync.DeleteShipperAsync(model.Id);

        return RedirectToAction("Index");
    }
}