        using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrderMe.Infrastructure.Constants.DataConstants;
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
        public virtual ApplicationUser User { get; set; } = null!;

        [Required, MaxLength(NameMaxLength)]
        [Comment("Garage Name")]
        public string Name { get; set; }

        [Required]
        [Comment("Garage's location")]
        // Property to store the double array as JSON in the database
        [Column(TypeName = "nvarchar(max)")]
        public string LocationJson { get; set; }

        // Actual array property in the model (not stored in the database)
        [NotMapped]
        public double[] LocationArray
        {
            get => JsonConvert.DeserializeObject<double[]>(LocationJson);
            set => LocationJson = JsonConvert.SerializeObject(value);
        }

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
