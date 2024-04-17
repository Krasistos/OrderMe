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



            return View(await vehicleService.AllVehiclesOfGarageAsync(garageId));
        }

        [HttpGet]
        public async Task<IActionResult> AddVehicle(int garageId)
        {
            return View(garageId);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(VehicleRegistrationViewModel model, int garageId)
        {
            if (model != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await vehicleService.CreateVehicleAsync(model, garageId);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Location", "Invalid location format");
                return View(model);
            }
        }


    }
}
