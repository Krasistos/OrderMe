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

        public OrderRideService(IRepository repos)
        {
            repository = repos;
        }

        public async Task<Driver> GetFreeDriver()
        {
            return repository.AllReadOnly<Driver>().FirstOrDefault(d=>d.IsActive != true);
        }

        public async Task<Vehicle> GetFreeVehicle()
        {
            return repository.AllReadOnly<Vehicle>().FirstOrDefault(v=>v.IsUsed != true);
        }

        public async Task OrderRideAsync(OrderRideForm model)
        {
            var orderRide = new RideOrder
            {
                UserId = model.UserId,
                DriverId = model.DriverId,
                VehicleId = model.VehicleId,
                PickUpLocationJson = JsonConvert.SerializeObject(model.PickupLocationArray),
                DropOffLocationJson = JsonConvert.SerializeObject(model.DropOffLocationArray),
                SceduledFor = DateTime.Now
            };


            await repository.AddAsync(orderRide);
        }
    }
}
