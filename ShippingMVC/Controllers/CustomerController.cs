using ApplicationCore.Contracts.Services;
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
}