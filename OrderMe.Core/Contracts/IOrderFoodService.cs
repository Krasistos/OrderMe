using OrderMe.Core.Models.OrderFood;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Contracts
{
    public interface IOrderFoodService
    {
        Task<Driver> GetFreeDriver();
        Task<Vehicle> GetFreeVehicle();
        Task<Cart> CreateCart(string userId);
        Task OrderFoodAsync(OrderFoodForm model);

    }
}
