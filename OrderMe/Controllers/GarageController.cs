using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;

namespace OrderMe.Controllers
{
    public class GarageController : BaseController
    {
        private readonly IGarageService garageService;

        public GarageController(IGarageService _garageService)
        {
            this.garageService = _garageService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await garageService.AllGaragesAsync());
        }

        public async Task<IActionResult> ListVehicles(int id)
        {
            return View();
           // return View(await garageService.AllVehiclesOfGarageAsync(id));
        }

        public async Task<IActionResult> SeeOnMap(int id)
        {
            return View();
           // return View(await garageService.GetGarageAsync(id));
        }
    }
}
