using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services;

public class CustomerServiceAsync: ICustomerServiceAsync
{
    private readonly ICustomerRepositoryAsyncAsync _customerRepositoryAsyncAsync;

    public CustomerServiceAsync(ICustomerRepositoryAsyncAsync customerRepositoryAsyncAsync)
    {
        _customerRepositoryAsyncAsync = customerRepositoryAsyncAsync;
    }

    public async Task<CustomerResponseModel> GetCustomerByIdAsync(int id)
    {
        var result = await _customerRepositoryAsyncAsync.GetByIdAsync(id);

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

    public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync()
    {
        var result = await _customerRepositoryAsyncAsync.GetAllAsync();

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

    public Task<int> AddCustomerAsync(CustomerRequestModel model)
    {
        return _customerRepositoryAsyncAsync.InsertAsync(new Customer()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Email = model.Email,
            Location = model.Location
        });
    }

    public Task<int> UpdateCustomerAsync(CustomerRequestModel model)
    {
        return _customerRepositoryAsyncAsync.UpdateAsync(new Customer()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Email = model.Email,
            Location = model.Location
        });
    }

    public Task<int> DeleteCustomerAsync(int id)
    {
        return _customerRepositoryAsyncAsync.DeleteByIdAsync(id);
    }
}