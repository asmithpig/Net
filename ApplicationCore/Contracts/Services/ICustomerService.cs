using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomers();
}