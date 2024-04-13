using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static OrderMe.Infrastructure.Constants.DataConstants;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("OrderMe Agency")]
    public class OrderMeAgency
    {
        [Key]
        [Comment("Agency Identifier")]
        public int Id { get; set; }
        [Required,MaxLength(OrderMeAgencyNameMaxLength)]
        [Comment("Agency Name")]
        public string Name { get; set; }

        // Navigation properties
        public List<Restaurant> Restaurants { get; set;} = new List<Restaurant>();

        public List<Garage> Garages { get; set;} = new List<Garage>();

    }
}
