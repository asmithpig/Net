using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface ICustomerService
{
    
    Task<CustomerResponseModel> GetCandidateById(int id);
    
    Task<IEnumerable<CustomerResponseModel>> GetAllCandidates();
    
    Task<int> AddCustomer(CustomerRequestModel model);
    
    Task<int> UpdateCustomer(CustomerRequestModel model);
    
    Task<int> DeleteCustomer(int id);
    
}