using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Walks.API.Models.Domain;

namespace Walks.API.Models.Dtos
{
	public class RegionDto
	{
        public Guid GUID { get; set; }
        public string Code { get; set; }
        public string RegionName { get; set; }
        public string? RegionImgUrl { get; set; }
        public bool IsClosed { get; set; }

        public ICollection<WalkDto> Walks { get; set; }
    }
}

