using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Garage;
using OrderMe.Infrastructure.Data;
using OrderMe.Infrastructure.Data.Models;
using System.Security.Claims;

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

        [HttpGet]
        public async Task<IActionResult> RegisterGarage()
        {
            //some form which they have to fill 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>RegisterGarage(GarageRegistrationViewModel model)
        {
            if (model != null)
            {
                await garageService.CreateGarageAsync(model,User.Id());

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle invalid location format (shouldn't normally happen with client-side validation)
                ModelState.AddModelError("Location", "Invalid location format");
                return View(model);
            }
        }

        public async Task<IActionResult> ListVehicles(int id)
        {
            return View();
            // return View(await garageService.AllVehiclesOfGarageAsync(id));
        }

        public async Task<IActionResult> AddVehicle(int id)
        {
            return View();
        }

        public async Task<IActionResult> EditVehicle(int id)
        {
            return View();
        }

        public async Task<IActionResult> DeleteVehicle(int id)
        {
            return View();
        }
    }
}
