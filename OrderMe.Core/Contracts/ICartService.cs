using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Contracts
{
    public interface ICartService
    {
        Task AddMenuItemCart(int menuItemId, int cartId);
        Task DecreaseQuantityOfMenuItem(int menuItemId, int cartId);
        Task IncreaseQuantityOfMenuItem(int menuItemId, int cartId);
        Task RemoveMenuItemFromCart(int menuItemId, int cartId);

        Task<Cart> GetCartByIdAsync(int cartId);

    }
}
