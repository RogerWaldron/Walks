using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Walks.API.Models.Dtos
{
	public class DifficultyDto
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_.-]{2,20}",
             ErrorMessage = "The {0} must be 2 to 20 valid characters which are any digit, any letter and -._@+.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public required string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}

