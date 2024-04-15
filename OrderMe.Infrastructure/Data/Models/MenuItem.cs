using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static OrderMe.Infrastructure.Constants.DataConstants.MenuItem;
using static OrderMe.Infrastructure.Constants.DataConstants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Menu Item")]
    public class MenuItem
    {
        [Key]
        [Comment("Menu Item Identifier")]
        public int Id { get; set; }

        [Required, MaxLength(NameMaxLength)]
        [Comment("Name of the menu item")]
        public string Name { get; set; } = string.Empty;
     
        [Required, Range(PriceMinValue, PriceMaxValue)]
        [Comment("Price of the menu item")]
        public decimal Price { get; set; }

        [Required, Range(QuantityMinValue, QuantityMaxValue)]
        [Comment("Quantity of the menu item")]
        public int Quantity { get; set; }

        //display
        [Required, MaxLength(DescriptionMaxLength)]
        [Comment("Description of the menu item")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Image of the menu item")]
        public byte[] ImageData { get; set; } // Byte array to store image data

        [NotMapped] 
        public IFormFile ImageFile { get; set; } // Property for uploading image file
    }
}
