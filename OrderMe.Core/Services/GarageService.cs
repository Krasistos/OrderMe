using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
     //   private readonly UserManager<ApplicationUser> userManager;

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
                    Location = JsonConvert.DeserializeObject<double[]>(g.LocationJson),
                    IsActive = g.IsActive,
                    CreationDate = g.CreationDate,
                }).ToListAsync();
        }

        public Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync(int garageId)
        {
            throw new NotImplementedException();
        }

        public async Task<GarageIndexServiceModel> GetGarageByIdAsync(int garageId)
        {
            var garage = await repository.GetByIdAsync<Garage>(garageId);

            return new GarageIndexServiceModel
            {
                Id = garage.Id,
                UserId = garage.UserId,
                Name = garage.Name,
                Location = JsonConvert.DeserializeObject<double[]>(garage.LocationJson),
                IsActive = garage.IsActive,
                CreationDate = garage.CreationDate,
            };
        }


        public async Task CreateGarageAsync(GarageRegistrationViewModel model,string userId)
        {
            var garage = new Garage
            {
                Name = model.Name,
                UserId = userId,
                LocationJson = JsonConvert.SerializeObject(new double[] { model.Latitude, model.Longitude }),
                IsActive = model.IsActive,
                CreationDate = DateTime.Now
            };

            await repository.AddAsync(garage);
            await repository.SaveChangesAsync();
        }

        public async Task<int> UpdateGarageAsync(Garage garage)
        {
            var existingGarage = await repository.GetByIdAsync<Garage>(garage.Id);

            if (existingGarage == null)
            {
                // Garage not found
                return 0; // Or throw an exception, handle as needed
            }

            // Update properties of the existing garage entity
            existingGarage.Name = garage.Name;
            existingGarage.LocationJson = garage.LocationJson;
            existingGarage.IsActive = garage.IsActive;

            // No need to explicitly call _repository.Update(existingGarage)
            // EF Core change tracking will mark the entity as modified

            return await repository.SaveChangesAsync();
        }

        public async Task<int> DeleteGarageAsync(int id)
        {
            await repository.DeleteAsync<Garage>(id);
            return await repository.SaveChangesAsync();
        }
    }
}
