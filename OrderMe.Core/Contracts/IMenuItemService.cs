using OrderMe.Core.Models.MenuItem;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Contracts
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemIndexServiceModel>> AllMenuItemsOfRestaurantAsync(int restaurantId);
        Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
        Task CreateMenuItemAsync(AddMenuItemViewModel model);
        Task UpdateMenuItemAsync(MenuItemEditViewModel menuItem);
        Task DeleteMenuItemAsync(int id);
    }
}
