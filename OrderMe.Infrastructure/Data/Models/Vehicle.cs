using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static OrderMe.Infrastructure.Constants.DataConstants.Vehicle;

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
        [Comment("Is the vehicle in use")]
        public bool IsUsed { get; set; }

        [Required]
        [Comment("When was the vehicle added")]
        public DateTime AddedOn { get; set; }

    }
}