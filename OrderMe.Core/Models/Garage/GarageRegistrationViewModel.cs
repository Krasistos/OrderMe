﻿using System.ComponentModel.DataAnnotations;

using static OrderMe.Core.Constants.MessageConstants;
using static OrderMe.Infrastructure.Constants.DataConstants.Garage;

namespace OrderMe.Core.Models.Garage
{
    public class GarageRegistrationViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
       [StringLength(NameMaxLength,MinimumLength = NameMinLength,ErrorMessage = LengthMessage)]
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }

    }
}
