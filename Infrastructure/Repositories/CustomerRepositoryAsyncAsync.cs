using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CustomerRepositoryAsyncAsync: BaseRepositoryAsync<Customer>, ICustomerRepositoryAsyncAsync
{
    public CustomerRepositoryAsyncAsync(EShopDbContext context) : base(context)
    {
    }
}