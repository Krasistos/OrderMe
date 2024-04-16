using OrderMe.Core.Models;

namespace OrderMe.Core.Contracts
{
    public interface IGarageService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync();
        Task<IEnumerable<GarageIndexServiceModel>> AllGaragesAsync();
    }
}
