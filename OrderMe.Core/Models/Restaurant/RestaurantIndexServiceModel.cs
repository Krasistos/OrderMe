using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Core.Models.Restaurant
{
    public class RestaurantIndexServiceModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }

        public double[] Location { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}
