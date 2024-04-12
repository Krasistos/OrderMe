using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrderMe.Infrastructure.Constants.DataConstants;
using static OrderMe.Infrastructure.Constants.DataConstants.Restaurant;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Restaurant")]
    public class Restaurant
    {
        [Key]
        [Comment("Restaurant Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Owner Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required, MaxLength(NameMaxLength)]
        [Comment("Restaurant Name")]
        public string Name { get; set; }

        [Required, Range(LocationLatitudeMin, LocationLatitudeMax)]
        [Comment("Restaurant Address's Latitude")]
        public double LocationLat { get; set; }

        [Required, Range(LocationLongitudeMin, LocationLongitudeMax)]
        [Comment("Restaurant Address's Longituude")]
        public double LocationLng { get; set; }

        [Required]
        [Comment("Is the garage active")]
        public bool IsActive { get; set; } // prety much allways

        [Required]
        [Comment("When was the restaurant created")]
        public DateTime CreationDate { get; set; }

        [Required, Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }
    }
}
