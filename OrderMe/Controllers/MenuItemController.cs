using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.MenuItem;

namespace OrderMe.Controllers
{
    public class MenuItemController : BaseController
    {

        private readonly IMenuItemService menuItemService;

        public MenuItemController(IMenuItemService _menuItemService)
        {
            this.menuItemService = _menuItemService;
        }

        public async Task<IActionResult> Index(int restaurantId)
        {
            var menuItems = menuItemService.AllMenuItemsOfRestaurantAsync(restaurantId).Result.ToList();

            if(menuItems.Count != 0)
            {
                return View(await menuItemService.AllMenuItemsOfRestaurantAsync(restaurantId));
            }
            else
            {
                return View("AddFirstMenuItem", restaurantId);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddMenuItem(int restaurantId)
        {
            return View(new AddMenuItemViewModel { RestaurantId = restaurantId });
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuItem(AddMenuItemViewModel modelD)
        {
            if (modelD != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(modelD);
                }

                await menuItemService.CreateMenuItemAsync(modelD);

                return RedirectToAction(nameof(Index), "Restaurant", 1);
            }
            else
            {
                ModelState.AddModelError("Location", "Invalid location format");
                return View(modelD);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditMenuItem(int id)
        {
            var menuItem = await menuItemService.GetMenuItemByIdAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            var model = new MenuItemEditViewModel
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Quantity = menuItem.Quantity,
                RestaurantId = menuItem.RestaurantId
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> EditMenuItem(MenuItemEditViewModel model)
        {
            if (model != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await menuItemService.UpdateMenuItemAsync(model);

                return RedirectToAction(nameof(Index), "Restaurant", 1);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            if(await menuItemService.GetMenuItemByIdAsync(id) == null)
            {
                return NotFound();
            }

            await menuItemService.DeleteMenuItemAsync(id);
            return RedirectToAction(nameof(Index), "Restaurant", 1);
        }

    }
}
