using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using static OrderMe.Infrastructure.Constants.DataConstants.Vehicle;
using static OrderMe.Core.Constants.MessageConstants;
namespace OrderMe.Core.Models.Vehicle
{
    public class AddVehicleViewModel
    {

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MakeMaxLength, MinimumLength = MakeMinLength, ErrorMessage = LengthMessage)]
        public string Make { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength, ErrorMessage = LengthMessage)]
        public string Model { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(LicensePlateLength, ErrorMessage = LicenseLengthMessage)]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public IFormFile ImageFile { get; set; } // Property for uploading image file

        public int GarageId { get; set; }

    }
}
