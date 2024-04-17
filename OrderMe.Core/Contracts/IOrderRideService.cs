using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Models.OrderRide;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Contracts
{
    public interface IOrderRideService
    {
        Task OrderRideAsync(OrderRideForm model);

        Task<Driver> GetFreeDriver();
        Task<Vehicle> GetFreeVehicle();

    }
}
