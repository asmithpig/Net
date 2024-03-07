using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IEnumerable<Customer>> GetCustomersByCity();
}