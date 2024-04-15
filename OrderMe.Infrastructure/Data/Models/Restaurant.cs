using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [Required]
        [Comment("Restaurant's location")]
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
        [Comment("When was the restaurant created")]
        public DateTime CreationDate { get; set; }


        // Navigation properties
        public virtual List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
      
    }
}
