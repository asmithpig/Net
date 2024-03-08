using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services;

public class CustomerService: ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponseModel> GetCustomerById(int id)
    {
        var result = await _customerRepository.GetById(id);

        return new CustomerResponseModel()
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Mobile = result.Mobile,
            Email = result.Email,
            Location = result.Location
        };
    }

    public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomers()
    {
        var result = await _customerRepository.GetAll();

        return result.Select(x => new CustomerResponseModel()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Mobile = x.Mobile,
            Email = x.Email,
            Location = x.Location
        });
    }

    public Task<int> AddCustomer(CustomerRequestModel model)
    {
        return _customerRepository.Insert(new Customer()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Email = model.Email,
            Location = model.Location
        });
    }

    public Task<int> UpdateCustomer(CustomerRequestModel model)
    {
        return _customerRepository.Insert(new Customer()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Email = model.Email,
            Location = model.Location
        });
    }

    public Task<int> DeleteCustomer(int id)
    {
        return _customerRepository.DeleteById(id);
    }
}