using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Restaurant;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository repository;
        public RestaurantService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<RestaurantIndexServiceModel>> AllRestaurantsAsync()
        {
            return await repository.AllReadOnly<Restaurant>()
                .Select(g => new RestaurantIndexServiceModel
                {
                    Id = g.Id,
                    UserId = g.UserId,
                    Name = g.Name,
                    Location = JsonConvert.DeserializeObject<double[]>(g.LocationJson),
                    IsActive = g.IsActive,
                    CreationDate = g.CreationDate,
                }).ToListAsync();
        }

        public async Task CreateRestaurantAsync(RestaurantRegistrationViewModel model, string userId)
        {
            var restaurant = new Restaurant
            {
                Name = model.Name,
                UserId = userId,
                LocationJson = JsonConvert.SerializeObject(new double[] { model.Latitude, model.Longitude }),
                IsActive = true,
                CreationDate = DateTime.UtcNow,
            };

            await repository.AddAsync(restaurant);

            await repository.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int id)
        {
           await repository.DeleteAsync<Restaurant>(id);
            await repository.SaveChangesAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
           return await repository.GetByIdAsync<Restaurant>(restaurantId);
        }

        public async Task<int> UpdateRestaurantAsync(RestaurantEditViewModel restaurant)
        {
          var existingRestaurant = await repository.GetByIdAsync<Restaurant>(restaurant.Id);

            if (existingRestaurant == null)
            {
                throw new InvalidOperationException("Restaurant not found");
            }

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.LocationJson = JsonConvert.SerializeObject(new double[] { restaurant.Latitude, restaurant.Longitude });
            existingRestaurant.IsActive = restaurant.IsActive;

            return await repository.SaveChangesAsync();
        }

    }
}
