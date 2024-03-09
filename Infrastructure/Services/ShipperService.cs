using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.Contracts.Repositories;

namespace Infrastructure.Services;

public class ShipperService: IShipperService
{

    private readonly IShipperRepository _shipperRepository;

    public ShipperService(IShipperRepository shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }

    public async Task<ShipperResponseModel> GetShipperById(int id)
    {
        var result = await _shipperRepository.GetById(id);

        return new ShipperResponseModel()
        {
            Id = result.Id,
            CompanyName = result.CompanyName,
            Mobile = result.Mobile
        };
    }

    public async Task<IEnumerable<ShipperResponseModel>> GetAllShippers()
    {
        var result = await _shipperRepository.GetAll();

        return result.Select(x => new ShipperResponseModel()
        {
            Id = x.Id,
            CompanyName = x.CompanyName,
            Mobile = x.Mobile
        });
    }

    public Task<int> AddShipper(ShipperRequestModel model)
    {
        return _shipperRepository.Insert(new Shipper()
        {
            Id = model.Id,
            CompanyName = model.CompanyName,
            Mobile = model.Mobile
        });
    }

    public Task<int> UpdateShipper(ShipperRequestModel model)
    {
        return _shipperRepository.Update(new Shipper()
        {
            Id = model.Id,
            CompanyName = model.CompanyName,
            Mobile = model.Mobile
        });
    }

    public Task<int> DeleteShipper(int id)
    {
        return _shipperRepository.DeleteById(id);
    }
}