using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Walks.API.Models.Domain
{
	public class Region
	{
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

