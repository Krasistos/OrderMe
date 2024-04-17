using OrderMe.Core.Models.Garage;
using OrderMe.Core.Models.Restaurant;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Contracts
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantIndexServiceModel>> AllRestaurantsAsync();
        Task CreateRestaurantAsync(RestaurantRegistrationViewModel model, string userId);
        Task<int> UpdateRestaurantAsync(RestaurantEditViewModel garage);
        Task DeleteRestaurantAsync(int id);
        Task<Restaurant> GetRestaurantByIdAsync(int restaurantId);

    }
}
