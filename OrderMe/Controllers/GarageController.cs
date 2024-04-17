using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Garage;
using OrderMe.Infrastructure.Data;
using OrderMe.Infrastructure.Data.Models;
using System.Security.Claims;
using System.Transactions;

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
        public async Task<IActionResult> RegisterGarage(GarageRegistrationViewModel model)
        {
            if (model != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                await garageService.CreateGarageAsync(model, User.Id());

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
        public async Task<IActionResult> EditGarage(int id)
        {
            var garage = await garageService.GetGarageByIdAsync(id);

            if (garage == null)
            {
                return NotFound();
            }

            double[] location = JsonConvert.DeserializeObject<double[]>(garage.LocationJson);


            var model = new GarageEditViewModel
            {
                Id = garage.Id,
                Name = garage.Name,
                Latitude = location[0],
                Longitude = location[1],
                IsActive = garage.IsActive
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditGarage(GarageEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return the view with validation errors
                return View(model);
            }

            await garageService.UpdateGarageAsync(model);

            // Redirect to the garage index or details page after successful update
            return RedirectToAction("Index", "Garage");

        }



        public async Task<IActionResult> DeleteGarage(int id)
        {

            if (await garageService.GetGarageByIdAsync(id) == null)
            {
                return NotFound();
            }

            await garageService.DeleteGarageAsync(id);

            return RedirectToAction(nameof(Index));
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
