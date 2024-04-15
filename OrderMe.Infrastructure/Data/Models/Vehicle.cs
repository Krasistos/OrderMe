using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static OrderMe.Infrastructure.Constants.DataConstants.Vehicle;
using static OrderMe.Infrastructure.Constants.DataConstants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Vehicle")]
    public class Vehicle
    {
        [Key]
        [Comment("Vehicle Identifier")]
        public int Id { get; set; }

        [Required,MaxLength(LicensePlateLength)]
        [Comment("Vehicle's license plate")]
        public string LicensePlate { get; set; } = string.Empty;

        [Required,MaxLength(MakeMaxLength)]
        [Comment("Vehicle's make")]
        public string Make { get; set; }

        [Required,MaxLength(ModelMaxLength)]
        [Comment("Vehicle's model")]
        public string Model { get; set; }

        [Required]
        [Comment("Image URL of the menu item")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Is the vehicle in use")]
        public bool IsUsed { get; set; }

        [Required]
        [Comment("When was the vehicle added")]
        public DateTime AddedOn { get; set; }

        [Required]
        [Comment("Image of the menu item")]
        public byte[] ImageData { get; set; } // Byte array to store image data

        [NotMapped] 
        public IFormFile ImageFile { get; set; } // Property for uploading image file

    }
}