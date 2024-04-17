namespace OrderMe.Core.Models.Vehicle
{
    public class VehicleIndexServiceModel
    {

        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string Make { get; set; }
        public string Model { get; set; }

        public bool IsUsed { get; set; }

        public DateTime AddedOn { get; set; }

        public byte[] ImageData { get; set; } // Byte array to store image data

        public int GarageId { get; set; }
    }
}

