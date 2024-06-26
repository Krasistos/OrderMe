﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrderMe.Infrastructure.Data.Models
{
    [Comment("Driver")]
    public class Driver
    {
        [Key]
        [Comment("Driver Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Is the driver occupied")]
        public bool IsActive { get; set; }

        [Required]
        [Comment("When did the user become a driver")]
        public DateTime CreatedAt { get; set; }  // it should be set when the user becomes a driver

    }
}
