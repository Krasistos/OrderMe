using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task RefreshVehiclesAndDriversAsync()
        {
            var vehicles =  repository.All<Vehicle>();
            var drivers =  repository.All<Driver>();
            
            await vehicles.ForEachAsync(v => v.IsUsed = false);
            await drivers.ForEachAsync(d => d.IsActive = false);

            await repository.SaveChangesAsync();
        }
    }
}
