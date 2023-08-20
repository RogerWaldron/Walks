using System.ComponentModel.DataAnnotations;

namespace Walks.API.Models.Dtos
{
	public class RegionCreateDto
	{
        [Required(ErrorMessage = "Region name is required")]
        [MinLength(2, ErrorMessage = "Region name can not be less than two characters")]
        [MaxLength(150, ErrorMessage = "Region name to long")]
        public string RegionName { get; set; }
        public string Code { get; set; };
        public string? RegionImgUrl { get; set; }
        public bool IsClosed { get; set; }
    }
}

