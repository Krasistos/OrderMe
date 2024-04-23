using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.OrderRide;

namespace OrderMe.Controllers
{
    public class OrderRideController : BaseController
    {
        private readonly IOrderRideService orderRideService;

        public OrderRideController(IOrderRideService orderRideService)
        {
            this.orderRideService = orderRideService;
        }
        [HttpGet]
        public async Task<IActionResult> SubmitOrder()
        {
            //find driver and vehicle
            var driver = orderRideService.GetFreeDriver().Result;
            var vehicle = orderRideService.GetFreeVehicle().Result;


            if(driver == null || vehicle == null)
            {
                return View("CannotNow");
            }

            
            return View("SubmitOrder", new OrderRideForm { DriverId = driver.Id, VehicleId = vehicle.Id });
        }

        [HttpPost]

        public async Task<IActionResult> SubmitOrder(OrderRideForm model)
        {
            if (model != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                await orderRideService.OrderRideAsync(model);

                return RedirectToAction(nameof(Index),"Home",1);
            }
            else
            {
                // Handle invalid location format (shouldn't normally happen with client-side validation)
                ModelState.AddModelError("Location", "Invalid location format");
                return View(model);
            }
        }
    }
}
