using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models;
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

            var model=  await repository.AllReadOnly<Garage>()
                .Select(g => new GarageIndexServiceModel
            {
                Id = g.Id,
                Name = g.Name,
                Vehicles = AllVehiclesOfGarageAsync().Result.ToList(),
            }).ToListAsync();

            return model;

        }

        public async Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync()
        {
            var model = await repository.AllReadOnly<Vehicle>()
                .Select(v => new VehicleIndexServiceModel
                {
                    Id = v.Id,
                    Make = v.Make,
                    GargeId = v.GarageId
                }).ToListAsync();

            return model;
        }
    }
}
