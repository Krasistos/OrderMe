using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Ride Order")]
    public class RideOrder
    {
        [Key]
        [Comment("Ride Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Customer Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;


        /// <summary>
        /// DRIVER AND VEHICLE
        /// </summary>

        [Required]
        [Comment("Driver Identifier")]
        public int DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]
        public virtual Driver Driver { get; set; } = null!;

        [Required]
        [Comment("Vehicle Identifier")]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; } = null!;

        /// <summary>
        /// BOTH LOCATIONS
        /// </summary>

        [Required]
        [Comment("Pickup Location")]
        // Property to store the double array as JSON in the database
        [Column(TypeName = "nvarchar(max)")]
        public string PickUpLocationJson { get; set; }

        // Actual array property in the model (not stored in the database)
        [NotMapped]
        public double[] PickUpLocationArray
        {
            get => JsonConvert.DeserializeObject<double[]>(PickUpLocationJson);
            set => PickUpLocationJson = JsonConvert.SerializeObject(value);
        }
        [Required]
        [Comment("Drop off Location")] 
        // Property to store the double array as JSON in the database
        [Column(TypeName = "nvarchar(max)")]
        public string DropOffLocationJson { get; set; }

        // Actual array property in the model (not stored in the database)
        [NotMapped]
        public double[] DropOffLocationArray
        {
            get => JsonConvert.DeserializeObject<double[]>(DropOffLocationJson);
            set => DropOffLocationJson = JsonConvert.SerializeObject(value);
        }

        [Required]
        [Comment("The sceduled date and time for the ride")]
        public DateTime SceduledFor { get; set; }
    }
}
