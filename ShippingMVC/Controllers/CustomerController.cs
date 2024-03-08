using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Mvc;
using ShippingMVC.Models;

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