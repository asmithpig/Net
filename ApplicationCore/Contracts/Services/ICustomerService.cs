using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface ICustomerService
{
    
    Task<CustomerResponseModel> GetCustomerById(int id);
    
    Task<IEnumerable<CustomerResponseModel>> GetAllCustomers();
    
    Task<int> AddCustomer(CustomerRequestModel model);
    
    Task<int> UpdateCustomer(CustomerRequestModel model);
    
    Task<int> DeleteCustomer(int id);
    
}