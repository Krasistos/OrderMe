using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Vehicle;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync( int garageId)
        {
            return await repository.AllReadOnly<Vehicle>()
                .Where(v=>v.GarageId == garageId)
                .Select(v=> new VehicleIndexServiceModel
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    LicensePlate = v.LicensePlate,
                    ImageData = v.ImageData,
                    GarageId = v.GarageId
                }).ToListAsync();
        }

        public Task CreateVehicleAsync(VehicleRegistrationViewModel model, int garageId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVehicleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateVehicleAsync(VehicleEditViewModel vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
