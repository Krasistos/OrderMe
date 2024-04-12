using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static OrderMe.Infrastructure.Constants.DataConstants.MenuItem;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Menu Item")]
    public class MenuItem
    {
        [Key]
        [Comment("Menu Item Identifier")]
        public int Id { get; set; }

        [Required,MaxLength(NameMaxLength)]
        [Comment("Name of the menu item")]
        public string Name { get; set; } = string.Empty;

        [Required,MaxLength(DescriptionMaxLength)]
        [Comment("Description of the menu item")]
        public string Description { get; set; } = string.Empty;

        [Required,Range(PriceMinValue,PriceMaxValue)]
        [Comment("Price of the menu item")]
        public decimal Price { get; set; }

        [Required,Range(QuantityMinValue, QuantityMaxValue)]
        [Comment("When was the menu item added")]
        public int Quantity { get; set; } // needed for the cart functionality
    }
}
