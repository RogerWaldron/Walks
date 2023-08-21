using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Walks.API.Models.Domain;

namespace Walks.API.Models.Dtos
{
	public class WalkDto
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid GUID { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_.-]{2,150}",
             ErrorMessage = "The {0} must be 2 to 150 valid characters which are any digit, any letter and -._@+.")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "WalkName")]
        public required string WalkName { get; set; }
        public required string Description { get; set; }
        public double? DistanceInKm { get; set; }
        public string? WalkImgUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsClosed { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        [ForeignKey("DifficultyId")]
        public DifficultyDto Difficulty { get; set; }
    }
}

