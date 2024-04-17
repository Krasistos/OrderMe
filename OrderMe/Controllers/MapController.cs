using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using OrderMe.Core.Contracts;

namespace OrderMe.Controllers
{
    public class MapController : BaseController
    {

        private readonly IGarageService garageService;
        private readonly IRestaurantService restaurantServ;
        public MapController(IGarageService _garageService, IRestaurantService restaurantServ)
        {
            this.garageService = _garageService;
            this.restaurantServ = restaurantServ;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult SaveMarker(double latitude, double longitude)
        //{
        //  //  return View("SaveMarker", new SaveMarkerViewModel { Latitude = latitude, Longitude = longitude });

        //}

        public async Task<IActionResult> SeeGarageOnMap(int garageId)
        {

            var garage = await garageService.GetGarageByIdAsync(garageId);
            if(garage == null)
            {
                return NotFound();
            }

            double[] location = JsonConvert.DeserializeObject < double[]>(garage.LocationJson);


            if (garage == null || location ==null || location.Length != 2)
            {
                return BadRequest();
            }

            ViewBag.Latitude = location[0];
            ViewBag.Longitude = location[1];
            return PartialView("_MapPartialGarage"); // Return the partial view for the map
        }

        public async Task<IActionResult> SeeRestaurantOnMap(int restaurantId)
        {

            var restaurant = await restaurantServ.GetRestaurantByIdAsync(restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }

            double[] location = JsonConvert.DeserializeObject<double[]>(restaurant.LocationJson);


            if (restaurant == null || location == null || location.Length != 2)
            {
                return BadRequest();
            }

            ViewBag.Latitude = location[0];
            ViewBag.Longitude = location[1];
            return PartialView("_MapPartialRestaurant"); // Return the partial view for the map
        }
    }
}