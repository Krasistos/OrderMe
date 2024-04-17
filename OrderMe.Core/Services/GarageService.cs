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


        public async Task<Garage> GetGarageByIdAsync(int garageId)
        {
            return await repository.GetByIdAsync<Garage>(garageId);
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

        public async Task UpdateGarageAsync(GarageEditViewModel model)
        {
            var existingGarage = await repository.GetByIdAsync<Garage>(model.Id);

            if (existingGarage == null)
            {
                throw new InvalidOperationException("Garge not found");
            }

            existingGarage.Name = model.Name;
            existingGarage.IsActive = model.IsActive;
            existingGarage.LocationJson = JsonConvert.SerializeObject(new double[] { model.Latitude, model.Longitude });

            // No need to explicitly call _repository.Update(existingGarage)
            // EF Core change tracking will mark the entity as modified

             await repository.SaveChangesAsync();
        }

        public async Task DeleteGarageAsync(int id)
        {
            await repository.DeleteAsync<Garage>(id);
            await repository.SaveChangesAsync();
        }
    }
}
