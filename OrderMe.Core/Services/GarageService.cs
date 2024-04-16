using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Garage;
using OrderMe.Core.Models.Vehicle;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{
    public class GarageService : IGarageService
    {

        private readonly IRepository repository;

        public GarageService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<GarageIndexServiceModel>> AllGaragesAsync()
        {
            return await repository.AllReadOnly<Garage>()
                .Select(g => new GarageIndexServiceModel
                {
                    Id = g.Id,
                    UserId = g.UserId,
                    Name = g.Name,
                    Location = g.LocationArray,
                    IsActive = g.IsActive,
                    CreationDate = g.CreationDate,
                }).ToListAsync();
        }

        public Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync(int garageId)
        {
            throw new NotImplementedException();
        }
    }
}
