using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface IShipperServiceAsync
{
    Task<ShipperResponseModel> GetShipperByIdAsync(int id);
    
    Task<IEnumerable<ShipperResponseModel>> GetAllShippersAsync();
    
    Task<int> AddShipperAsync(ShipperRequestModel model);
    
    Task<int> UpdateShipperAsync(ShipperRequestModel model);
    
    Task<int> DeleteShipperAsync(int id);
}