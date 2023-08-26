using System.ComponentModel.DataAnnotations;

namespace Walks.API.Models.Dtos
{
    public class RegionUpdateDto
	{
        public Guid GUID { get; set; }
        [Required]
        public required string RegionName { get; set; }
        public required string Code { get; set; }
        public string? RegionImgUrl { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public bool IsClosed { get; set; }
    }
}

