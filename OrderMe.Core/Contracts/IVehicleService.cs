using OrderMe.Core.Models.Vehicle;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync(int garageId);
        Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
        Task CreateVehicleAsync(VehicleRegistrationViewModel model,int garageId);
        Task UpdateVehicleAsync(VehicleEditViewModel vehicle);
        Task DeleteVehicleAsync(int id);

    }
}
