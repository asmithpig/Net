using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ShipperRepository: BaseRepository<Shipper>, IShipperRepository
{
    public ShipperRepository(EShopDbContext context) : base(context)
    {
    }
}