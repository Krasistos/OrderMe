using OrderMe.Core.Models.Garage;
using OrderMe.Core.Models.Vehicle;

namespace OrderMe.Core.Contracts
{
    public interface IGarageService
    {
        Task<IEnumerable<GarageIndexServiceModel>> AllGaragesAsync();
        Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync(int garageId);
    }
}
