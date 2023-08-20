using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Walks.API.Models.Domain
{
	public class Region
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid GUID { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9._@+-]{2,150}",
              ErrorMessage = "The {0} must be 1 to 150 valid characters which are any digit, any letter and -._@+.")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "RegionName")]
        public string RegionName { get; set; }
        [Required]
        public string Code { get; set; } = "NSW";
        public string? RegionImgUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsClosed { get; set; }


        // Foreign Key
        [Required]
        public int WalkId { get; set; }

        [ForeignKey("WalkId")]
        public Walk Walk { get; set; }

        // Foreign Key
        [Required]
        public int DifficultyId { get; set; }

        [ForeignKey("DifficultyId")]
        public Difficulty Difficulty { get; set; }
    }
}

