using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OrderMe.Core.Contracts;

namespace OrderMe.Controllers
{
    public class MapController : BaseController
    {

        private readonly IGarageService garageService;
        public MapController(IGarageService _garageService)
        {
            this.garageService = _garageService;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult SaveMarker(double latitude, double longitude)
        //{
        //  //  return View("SaveMarker", new SaveMarkerViewModel { Latitude = latitude, Longitude = longitude });

        //}

        public async Task<IActionResult> SeeOnMap(int garageId)
        {

            var garage = await garageService.GetGarageByIdAsync(garageId);

            if (garage == null || garage.Location == null || garage.Location.Length != 2)
            {
                return BadRequest();
            }

            ViewBag.Latitude = garage.Location[0];
            ViewBag.Longitude = garage.Location[1];
            return PartialView("_MapPartial"); // Return the partial view for the map
        }
    }
}