using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderMe.Core.Models.Vehicle;

namespace OrderMe.Core.Models.Garage
{
    public class GarageIndexServiceModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }

        public double[] Location { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public List<VehicleIndexServiceModel> Vehicles { get; set; }
    }
}
