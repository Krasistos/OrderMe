using OrderMe.Core.Contracts;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{
    public class CartService : ICartService
    {
        private IRepository repository;
        public CartService(IRepository repository) { this.repository = repository;}

        public async Task AddMenuItemCart(int menuItemId, int cartId)
        {
            var menuItem = await repository.GetByIdAsync<MenuItem>(menuItemId);

            var cart = await repository.GetByIdAsync<Cart>(cartId);

             cart.MenuItems.Add(menuItem);

           await repository.SaveChangesAsync();
        }

        public async Task DecreaseQuantityOfMenuItem(int menuItemId, int cartId)
        {
            var cart = await repository.GetByIdAsync<Cart>(cartId);
            cart.MenuItems.Where(m=>m.Id == menuItemId).FirstOrDefault().Quantity--;

            await repository.SaveChangesAsync();
        }

        public async Task IncreaseQuantityOfMenuItem(int menuItemId, int cartId)
        {
            var cart = await repository.GetByIdAsync<Cart>(cartId);
            cart.MenuItems.Where(m => m.Id == menuItemId).FirstOrDefault().Quantity++;

            await repository.SaveChangesAsync();
        }

        public async Task RemoveMenuItemFromCart(int menuItemId, int cartId)
        {
            var cart = await repository.GetByIdAsync<Cart>(cartId);

            var menuItem = cart.MenuItems.Where(m => m.Id == menuItemId).FirstOrDefault();
            cart.MenuItems.Remove(menuItem);

            await repository.SaveChangesAsync();
        }
    }
}
