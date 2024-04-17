using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.MenuItem;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository repository;

        public MenuItemService(IRepository _repository)
        {
            this.repository = _repository;
        }


        public async Task<IEnumerable<MenuItemIndexServiceModel>> AllMenuItemsOfRestaurantAsync(int restaurantId)
        {
            return await repository.AllReadOnly<MenuItem>()
                .Where(m => m.RestaurantId == restaurantId)
                .Select(m => new MenuItemIndexServiceModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    Price = m.Price,
                    ImageData = m.ImageData,
                    RestaurantId = m.RestaurantId
                }).ToListAsync();
        }

        public async Task CreateMenuItemAsync(AddMenuItemViewModel model)
        {
            byte[] imageData = await GetImageDataAsync(model.ImageFile);

            var menuItem = new MenuItem
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = 1, // the items are allways on one just when u make an order the quantity is increased temporary
                ImageData = imageData,
                RestaurantId = model.RestaurantId
            };

            await repository.AddAsync(menuItem);
            await repository.SaveChangesAsync();
        }
        public async Task UpdateMenuItemAsync(MenuItemEditViewModel menuItem)
        {
            var existingMenuItem = await repository.GetByIdAsync<MenuItem>(menuItem.Id);

            if (existingMenuItem == null)
            {
                throw new InvalidOperationException("MenuItem not found");
            }

            existingMenuItem.Name = menuItem.Name;
            existingMenuItem.Description = menuItem.Description;
            existingMenuItem.Price = menuItem.Price;
            existingMenuItem.Quantity = menuItem.Quantity;

            if(menuItem.ImageFile != null)
            {
                existingMenuItem.ImageData = await GetImageDataAsync(menuItem.ImageFile);
            }

            await repository.SaveChangesAsync();
        }


        public async Task DeleteMenuItemAsync(int id)
        {
            await repository.DeleteAsync<MenuItem>(id);
            await repository.SaveChangesAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
        {
            return await repository.GetByIdAsync<MenuItem>(menuItemId);
        }

        private async Task<byte[]> GetImageDataAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
