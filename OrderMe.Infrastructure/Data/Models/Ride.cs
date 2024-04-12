using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrderMe.Infrastructure.Constants.DataConstants.Ride;
using static OrderMe.Infrastructure.Constants.DataConstants;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Ride")]
    public class Ride
    {
        [Key]
        [Comment("Ride Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Customer Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Driver Identifier")]
        public int DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]
        public virtual Driver Driver { get; set; } = null!;

        /// <summary>
        /// The pickup and drop off locations
        /// </summary>
        /// 
        [Required, Range(LocationLatitudeMin, LocationLatitudeMax)]
        [Comment("Pickup location latitude")]
        public double PickupLocationLat { get; set; }

        [Required, Range(LocationLongitudeMin, LocationLongitudeMax)]
        [Comment("Pickup location longitude")]
        public double PickupLocationLng { get; set; }

        [Required,Range(LocationLatitudeMin,LocationLatitudeMax)]
        [Comment("Drop off location latitude")]
        public double DropOffLocationLat { get; set; }

        [Required, Range(LocationLongitudeMin, LocationLongitudeMax)]
        [Comment("Drop off location longitude")]
        public double DropOffLocationLng { get; set; }

        [Required]
        [Comment("The sceduled date and time for the ride")]
        public DateTime SceduledFor { get; set; }

        [Comment("Ride status"),MaxLength(StatusMaxLength)] // not required
        public string Status { get; set; }

    }
}
