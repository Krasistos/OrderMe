using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Cart")]
    public class Cart
    {
        [Key]
        [Comment("Cart Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Customer Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        // Navigation properties
        public virtual List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
