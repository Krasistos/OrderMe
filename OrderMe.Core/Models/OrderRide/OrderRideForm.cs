namespace OrderMe.Core.Models.OrderRide
{
    public class OrderRideForm
    {
        public string UserId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }

        public double LatitudePick { get; set; }
        public double LongitudePick { get; set; }

        public double LatitudeDrop { get; set; }
        public double LongitudeDrop { get; set; }

        public DateTime SceduledFor { get; set; }

        public bool UsePersonalAddress { get; set; }

    }
}
