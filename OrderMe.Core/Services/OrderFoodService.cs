using Microsoft.AspNetCore.Identity;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.OrderFood;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{

    public class OrderFoodService : IOrderFoodService
    {
        private readonly IRepository repository;

        public OrderFoodService(IRepository _repo)
        {
            repository = _repo;
        }

        public async Task<Cart> CreateCart(string userId)
        {
            Cart cart = new Cart
            {
                UserId = userId,
                MenuItems = new List<MenuItem>()
            };

            await repository.AddAsync(cart);
            return cart;
        }

        public async Task<Driver> GetFreeDriver()
        {
            return repository.AllReadOnly<Driver>().FirstOrDefault(d => d.IsActive != true);
        }

        public async Task<Vehicle> GetFreeVehicle()
        {
            return repository.AllReadOnly<Vehicle>().FirstOrDefault(v => v.IsUsed != true);
        }

        public Task OrderFoodAsync(OrderFoodForm model)
        {
            throw new NotImplementedException();
        }
    }
}
