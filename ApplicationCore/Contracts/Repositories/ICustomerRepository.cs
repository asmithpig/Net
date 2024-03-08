using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetCustomersByLocation();
    
}