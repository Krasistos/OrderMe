using OrderMe.Core.Models.Garage;
using OrderMe.Core.Models.Vehicle;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Contracts
{
    public interface IGarageService
    {
        Task<IEnumerable<GarageIndexServiceModel>> AllGaragesAsync();
        Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync(int garageId);
        Task<GarageIndexServiceModel> GetGarageByIdAsync(int garageId);
        Task CreateGarageAsync(GarageRegistrationViewModel model,string userId);
        Task<int> UpdateGarageAsync(Garage garage);
        Task<int> DeleteGarageAsync(int id);
    }
}
