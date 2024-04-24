namespace OrderMe.Core.Models.OrderFood
{
    public class OrderFoodForm
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }

        public OrderMe.Infrastructure.Data.Models.Cart Cart { get; set; }

        public string UserId { get; set; }


        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public bool UsePersonalAddress { get; set; }
    }
}
