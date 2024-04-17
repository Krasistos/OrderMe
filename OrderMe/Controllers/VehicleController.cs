using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Vehicle;

namespace OrderMe.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService _vehicleService)
        {
            this.vehicleService = _vehicleService;
        }
        public async Task<IActionResult> Index(int garageId)
        {
            var vehicles = vehicleService.AllVehiclesOfGarageAsync(garageId).Result.ToList();

            if (vehicles.Count != 0)
            {
                return View(await vehicleService.AllVehiclesOfGarageAsync(garageId));
            }
            else
            {
                return View("AddFirstVehicle", garageId );
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddVehicle(int garageId)
        {
            return View(new AddVehicleViewModel { GarageId = garageId });
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(AddVehicleViewModel modelD)
        {
            if (modelD != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(modelD);
                }

                await vehicleService.CreateVehicleAsync(modelD);

                return RedirectToAction(nameof(Index), "Garage", 1);
            }
            else
            {
                ModelState.AddModelError("Location", "Invalid location format");
                return View(modelD);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditVehicle(int id)
        {
            var vehicle = await vehicleService.GetVehicleByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            var modelD = new VehicleEditViewModel
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                LicensePlate = vehicle.LicensePlate,
                ImageFile = vehicle.ImageFile,
                IsUsed = vehicle.IsUsed,
                GarageId = vehicle.GarageId
            };

            return View(modelD);
        }

        [HttpPost]

        public async Task<IActionResult> EditVehicle(VehicleEditViewModel modelD)
        {
            if (modelD != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(modelD);
                }

                await vehicleService.UpdateVehicleAsync(modelD);

                return RedirectToAction(nameof(Index), "Garage", 1);
            }
            else
            {
                return View(modelD);
            }
        }

        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (await vehicleService.GetVehicleByIdAsync(id) == null)
            {
                return NotFound();
            }

            await vehicleService.DeleteVehicleAsync(id);

            return RedirectToAction(nameof(Index), "Garage", 1);
        }
    }
}
