using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> ListMeals(int id)
        {
            return View();
            // return View(await restaurantService.AllMealsOfRestaurantAsync(id));
        }

        public async Task<IActionResult> AddMeal(int id)
        {
            return View();
        }

        public async Task<IActionResult> EditMeal(int id)
        {
            return View();
        }
    }
}
