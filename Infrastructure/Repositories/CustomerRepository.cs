using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(EShopDbContext context) : base(context)
    {
    }
}