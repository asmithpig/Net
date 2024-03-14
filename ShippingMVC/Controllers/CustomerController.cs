using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class CustomerController : Controller
{

    private readonly ICustomerServiceAsync _customerServiceAsync;

    public CustomerController(ICustomerServiceAsync customerServiceAsync)
    {
        _customerServiceAsync = customerServiceAsync;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var customers = await _customerServiceAsync.GetAllCustomersAsync();
        
        return View(customers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerRequestModel model)
    {
        if (ModelState.IsValid)
        {
            await _customerServiceAsync.AddCustomerAsync(model);
            return RedirectToAction("Index");
        }

        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

        var result = await _customerServiceAsync.GetCustomerByIdAsync(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CustomerRequestModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _customerServiceAsync.UpdateCustomerAsync(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(new CustomerResponseModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    Location = model.Location
                });
            }
        }
        
        return View(new CustomerResponseModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Email = model.Email,
            Location = model.Location
        });
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {

        var result = await _customerServiceAsync.GetCustomerByIdAsync(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CustomerResponseModel model)
    {
        await _customerServiceAsync.DeleteCustomerAsync(model.Id);

        return RedirectToAction("Index");
    }
    
}