using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ShippingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerServiceAsync _customerServiceAsync;

    public CustomerController(ICustomerServiceAsync customerServiceAsync)
    {
        _customerServiceAsync = customerServiceAsync;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerServiceAsync.GetAllCustomersAsync();

        if (!customers.Any())
        {
            return NotFound(new { errorMessage = "No Customers Found" }); 
        }
        
        return Ok(customers);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerServiceAsync.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound(new { errorMessage = "No Customer Found for id: " + id });
        }
        return Ok(customer);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody]CustomerRequestModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _customerServiceAsync.AddCustomerAsync(model);

            return Ok(result);
        }

        return BadRequest("Invalid data");
    }

    [HttpPut]
    [Route("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id, CustomerRequestModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var result = await _customerServiceAsync.UpdateCustomerAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid data");
            }
        }

        return BadRequest("Invalid data");
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {

        var result = await _customerServiceAsync.DeleteCustomerAsync(id);
        
        return Ok(result);
    }
}