using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Restaurant;

namespace OrderMe.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService _restaurantService)
        {
            this.restaurantService = _restaurantService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await restaurantService.AllRestaurantsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> RegisterRestaurant()
        {
            //some form which they have to fill 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRestaurant(RestaurantRegistrationViewModel model)
        {
            if (model != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                await restaurantService.CreateRestaurantAsync(model, User.Id());

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle invalid location format (shouldn't normally happen with client-side validation)
                ModelState.AddModelError("Location", "Invalid location format");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditRestaurant(int id)
        {
            var restaurant = await restaurantService.GetRestaurantByIdAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            double[] location = JsonConvert.DeserializeObject < double[]>(restaurant.LocationJson);

            var model = new RestaurantEditViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Latitude = location[0],
                Longitude = location[1],
                IsActive = restaurant.IsActive
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRestaurant(RestaurantEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await restaurantService.UpdateRestaurantAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            if(await restaurantService.GetRestaurantByIdAsync(id) == null)
            {
                return NotFound();
            }

            await restaurantService.DeleteRestaurantAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
