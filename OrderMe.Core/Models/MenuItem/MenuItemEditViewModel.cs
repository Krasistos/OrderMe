using Microsoft.AspNetCore.Http;

namespace OrderMe.Core.Models.MenuItem
{
    public class MenuItemEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageFile { get; set; }
        public int Quantity { get; set; }
        public int RestaurantId { get; set; }

    }
}
