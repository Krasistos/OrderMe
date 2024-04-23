using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.OrderRide;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{
    public class OrderRideService : IOrderRideService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderRideService(IRepository repos, UserManager<ApplicationUser> _userManager)
        {
            repository = repos;
            userManager = _userManager;
        }

        public async Task<Driver> GetFreeDriver()
        {
            return repository.AllReadOnly<Driver>().FirstOrDefault(d => d.IsActive != true);
        }

        public async Task<Vehicle> GetFreeVehicle()
        {
            return repository.AllReadOnly<Vehicle>().FirstOrDefault(v => v.IsUsed != true);
        }

        public async Task OrderRideAsync(OrderRideForm model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            var driver = await repository.GetByIdAsync<Driver>(model.DriverId);
            var vehicle = await repository.GetByIdAsync<Vehicle>(model.VehicleId);

            driver.IsActive = true;
            vehicle.IsUsed = true;
            
            var orderRide = new RideOrder
            {
                UserId = model.UserId,
                DriverId = model.DriverId,
                VehicleId = model.VehicleId,
                PickUpLocationJson = model.UsePersonalAddress ? user.LocationJson : JsonConvert.SerializeObject(new double[] { model.LatitudePick, model.LongitudePick }),
                DropOffLocationJson = JsonConvert.SerializeObject(new double[] { model.LatitudeDrop, model.LongitudeDrop }),
                SceduledFor = model.SceduledFor
            };

            await repository.AddAsync(orderRide);
            await repository.SaveChangesAsync();
        }
    }
}
