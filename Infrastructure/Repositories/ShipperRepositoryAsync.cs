using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ShipperRepositoryAsync: BaseRepositoryAsync<Shipper>, IShipperRepositoryAsync
{
    public ShipperRepositoryAsync(EShopDbContext context) : base(context)
    {
    }
}