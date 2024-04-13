using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Food Order")]
    public class FoodOrder
    {
        [Key]
        [Comment("Food Order Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Cart Identifier")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; } = null!;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Restaurant Identifier")]

        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; } = null!;

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
        /// LOCATION
        /// </summary>

        [Required]
        [Comment("Destination of food deliver")]
        // Property to store the double array as JSON in the database
        [Column(TypeName = "nvarchar(max)")]
        public string DestinationJson { get; set; }

        // Actual array property in the model (not stored in the database)
        [NotMapped]
        public double[] DestinationArray
        {
            get => JsonConvert.DeserializeObject<double[]>(DestinationJson);
            set => DestinationJson = JsonConvert.SerializeObject(value);
        }
    }

}
