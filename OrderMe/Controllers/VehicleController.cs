using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;

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


    }
}
