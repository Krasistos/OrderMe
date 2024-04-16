using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Models
{
    public class MenuAndVehicleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation properties
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }

}
