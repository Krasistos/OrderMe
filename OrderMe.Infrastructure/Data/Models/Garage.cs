using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrderMe.Infrastructure.Constants.DataConstants.Garage;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Garage")]
    public class Garage
    {
        [Key]
        [Comment("Garage Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Owner Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required, MaxLength()]
        [Comment("Garage Name")]
        public string Name { get; set; }

        [Required, Range(LocationLatitudeMin, LocationLatitudeMax)]
        [Comment("Garage Address's Latitude")]
        public double LocationLat { get; set; }

        [Required, Range(LocationLongitudeMin, LocationLongitudeMax)]
        [Comment("Garage Address's Longituude")]
        public double LocationLng { get; set; }

        [Required]
        [Comment("Is the garage active")]
        public bool IsActive { get; set; } // prety much allways

        [Required]
        [Comment("When was the garage created")]
        public DateTime CreationDate { get; set; }

        // Navigation properties
        public virtual List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
