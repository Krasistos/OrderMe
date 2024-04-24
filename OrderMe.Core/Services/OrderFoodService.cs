using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.MenuItem;
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
            await repository.SaveChangesAsync();

            return cart;
        }

        public async Task<List<MenuItemIndexServiceModel>> GetAllMenuItems()
        {
            return await repository.AllReadOnly<MenuItem>().Select(m => new MenuItemIndexServiceModel
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Quantity = m.Quantity,
                RestaurantId = m.RestaurantId,
                ImageData = m.ImageData,
            }).ToListAsync();
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
