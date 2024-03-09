using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace ShippingMVC.Controllers;

public class CustomerController : Controller
{

    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var customers = await _customerService.GetAllCustomers();
        
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
            await _customerService.AddCustomer(model);
            return RedirectToAction("Index");
        }

        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

        var result = await _customerService.GetCustomerById(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CustomerRequestModel model)
    {
        try
        {
            await _customerService.UpdateCustomer(model);

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
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {

        var result = await _customerService.GetCustomerById(id);
        
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CustomerResponseModel model)
    {
        await _customerService.DeleteCustomer(model.Id);

        return RedirectToAction("Index");
    }
    
}