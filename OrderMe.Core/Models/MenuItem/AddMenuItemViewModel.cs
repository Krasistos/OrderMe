using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using static OrderMe.Infrastructure.Constants.DataConstants.MenuItem;
using static OrderMe.Core.Constants.MessageConstants;

namespace OrderMe.Core.Models.MenuItem
{
    public class AddMenuItemViewModel
    {

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(PriceMinValue,PriceMaxValue, ErrorMessage = PriceMessage)]
        public decimal Price { get; set; }

        public IFormFile ImageFile { get; set; } // Property for uploading image file

        public int RestaurantId { get; set; }

    }
}
