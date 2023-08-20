using System.ComponentModel.DataAnnotations;

namespace Walks.API.Models.Dtos
{
	public class RegionUpdateDto
	{
        public Guid GUID { get; set; }
        [Required]
        public string RegionName { get; set; }
        public string Code { get; set; }
        public string? RegionImgUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsClosed { get; set; }
    }
}

