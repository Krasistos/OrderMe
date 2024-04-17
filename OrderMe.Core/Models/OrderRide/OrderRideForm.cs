namespace OrderMe.Core.Models.OrderRide
{
    public class OrderRideForm
    {
        public string UserId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }

        //lat and long
        public double[] PickupLocationArray { get; set; }
        public double[] DropOffLocationArray{ get; set; }

        public DateTime SceduledFor { get; set; }

    }
}
