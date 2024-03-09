using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface IShipperService
{
    Task<ShipperResponseModel> GetShipperById(int id);
    
    Task<IEnumerable<ShipperResponseModel>> GetAllShippers();
    
    Task<int> AddShipper(ShipperRequestModel model);
    
    Task<int> UpdateShipper(ShipperRequestModel model);
    
    Task<int> DeleteShipper(int id);
}