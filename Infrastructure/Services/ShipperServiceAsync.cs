using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.Contracts.Repositories;

namespace Infrastructure.Services;

public class ShipperServiceAsync: IShipperServiceAsync
{

    private readonly IShipperRepositoryAsync _shipperRepositoryAsync;

    public ShipperServiceAsync(IShipperRepositoryAsync shipperRepositoryAsync)
    {
        _shipperRepositoryAsync = shipperRepositoryAsync;
    }

    public async Task<ShipperResponseModel> GetShipperByIdAsync(int id)
    {
        var result = await _shipperRepositoryAsync.GetByIdAsync(id);

        return new ShipperResponseModel()
        {
            Id = result.Id,
            CompanyName = result.CompanyName,
            Mobile = result.Mobile
        };
    }

    public async Task<IEnumerable<ShipperResponseModel>> GetAllShippersAsync()
    {
        var result = await _shipperRepositoryAsync.GetAllAsync();

        return result.Select(x => new ShipperResponseModel()
        {
            Id = x.Id,
            CompanyName = x.CompanyName,
            Mobile = x.Mobile
        });
    }

    public Task<int> AddShipperAsync(ShipperRequestModel model)
    {
        return _shipperRepositoryAsync.InsertAsync(new Shipper()
        {
            Id = model.Id,
            CompanyName = model.CompanyName,
            Mobile = model.Mobile
        });
    }

    public Task<int> UpdateShipperAsync(ShipperRequestModel model)
    {
        return _shipperRepositoryAsync.UpdateAsync(new Shipper()
        {
            Id = model.Id,
            CompanyName = model.CompanyName,
            Mobile = model.Mobile
        });
    }

    public Task<int> DeleteShipperAsync(int id)
    {
        return _shipperRepositoryAsync.DeleteByIdAsync(id);
    }
}