using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.Vehicle;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMe.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<VehicleIndexServiceModel>> AllVehiclesOfGarageAsync(int garageId)
        {
            return await repository.AllReadOnly<Vehicle>()
                .Where(v => v.GarageId == garageId)
                .Select(v => new VehicleIndexServiceModel
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    LicensePlate = v.LicensePlate,
                    ImageData = v.ImageData,
                    GarageId = v.GarageId
                }).ToListAsync();
        }

        public async Task CreateVehicleAsync(VehicleRegistrationViewModel model, int garageId)
        {
            byte[] imageData = await GetImageDataAsync(model.ImageFile);

            var vehicle = new Vehicle
            {
                Make = model.Make,
                Model = model.Model,
                LicensePlate = model.LicensePlate,
                ImageData = imageData,
                IsUsed = false,
                AddedOn = DateTime.Now,
                GarageId = garageId
            };

            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(VehicleEditViewModel vehicle)
        {
            var existingVehicle = await repository.GetByIdAsync<Vehicle>(vehicle.Id);

            if (existingVehicle == null)
            {
                throw new InvalidOperationException("Vehicle not found");
            }

            existingVehicle.Make = vehicle.Make;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.LicensePlate = vehicle.LicensePlate;

            if (vehicle.ImageFile != null)
            {
                existingVehicle.ImageData = await GetImageDataAsync(vehicle.ImageFile);
            }

            await repository.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await repository.DeleteAsync<Vehicle>(id);
            await repository.SaveChangesAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            return await repository.GetByIdAsync<Vehicle>(vehicleId);
        }

        private async Task<byte[]> GetImageDataAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
