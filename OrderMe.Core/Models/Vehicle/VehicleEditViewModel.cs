using Microsoft.AspNetCore.Http;

namespace OrderMe.Core.Models.Vehicle
{
    public class VehicleEditViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsUsed { get; set; }
        public int GarageId { get; set; }

    }
}
