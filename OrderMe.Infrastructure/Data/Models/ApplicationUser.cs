using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrderMe.Infrastructure.Constants.DataConstants.ApplicationUserConstants;

namespace OrderMe.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Comment("User's addresss")]
        [Column(TypeName = "nvarchar(max)")]
        public string LocationJson { get; set; }

        [NotMapped]
        public double[] LocationArray
        {
            get => JsonConvert.DeserializeObject<double[]>(LocationJson);
            set => LocationJson = JsonConvert.SerializeObject(value);
        }
    }
}
