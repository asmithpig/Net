using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface ICustomerServiceAsync
{
    
    Task<CustomerResponseModel> GetCustomerByIdAsync(int id);
    
    Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync();
    
    Task<int> AddCustomerAsync(CustomerRequestModel model);
    
    Task<int> UpdateCustomerAsync(CustomerRequestModel model);
    
    Task<int> DeleteCustomerAsync(int id);
    
}