using Microsoft.AspNetCore.Mvc;
using ShippingMVC.Models;

namespace ShippingMVC.Controllers;

public class CustomerController : Controller
{
    List<Customer> customers = new List<Customer>();

    public CustomerController()
    {
        customers.Add(new Customer() { Id = 1, CustomerName = "May1", Address = "TX", Contact = "may1@amail.com" });
        customers.Add(new Customer() { Id = 1, CustomerName = "May2", Address = "CA", Contact = "may2@amail.com" });
        customers.Add(new Customer() { Id = 1, CustomerName = "May3", Address = "NY", Contact = "may3@amail.com" });
        customers.Add(new Customer() { Id = 1, CustomerName = "May4", Address = "MM", Contact = "may4@amail.com" });
    }

    // GET
    public IActionResult Index()
    {
        return View(customers);
    }
}