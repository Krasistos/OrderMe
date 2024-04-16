namespace OrderMe.Core.Models.Vehicle
{
    public class VehicleIndexServiceModel
    {
        public int Id { get; set; }
        public string Make { get; set; }

        public byte[] ImageData { get; set; }
        public int GargeId { get; set; }
    }
}
