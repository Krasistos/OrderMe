namespace OrderMe.Core.Models.MenuItem
{
    public class MenuItemIndexServiceModel
    {

        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal Price{ get; set; }
        public int  Quantity { get; set; }
        public byte[] ImageData { get; set; } // Byte array to store image data
        public int RestaurantId { get; set; }
    }
}

