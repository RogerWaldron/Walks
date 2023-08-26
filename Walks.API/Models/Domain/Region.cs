﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Walks.API.Models.Domain
{
    public class Region
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid GUID { get; set; }
        [RegularExpression(@"[a-zA-Z0-9._@+-]{2,150}",
              ErrorMessage = "The {0} must be 1 to 150 valid characters which are any digit, any letter and -._@+.")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "RegionName")]
        public required string RegionName { get; set; }
        public required string Code { get; set; }
        public string? RegionImgUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; } 
        public bool IsDeleted { get; set; }
        public bool IsClosed { get; set; }

        // Navigation
        [ForeignKey("WalkId")]
        public required ICollection<Walk> Walks { get; set; }
    }
}

