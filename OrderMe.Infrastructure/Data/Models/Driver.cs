using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static OrderMe.Infrastructure.Constants.DataConstants.Driver;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Driver")]
    public class Driver
    {
        [Key]
        [Comment("Driver Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Vehicle Identifier")]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; } = null!;

        [Required]
        [Comment("Is the driver occupied")]
        public bool IsActive { get; set; }

        [Required]
        [Comment("When did the user become a driver")]
        public DateTime CreatedAt { get; set; }  // it should be set when the user becomes a driver

        [Required,Range(RatingMinValue,RatingMaxValue)]
        [Comment("The rating of the driver")]
        public double Rating { get; set; }
    }
}
