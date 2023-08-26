namespace Walks.API.Models.Dtos
{
    public class RegionDto
	{
        public Guid GUID { get; set; }
        public required string Code { get; set; }
        public required string RegionName { get; set; }
        public string? RegionImgUrl { get; set; }
        public bool IsClosed { get; set; }

        public required ICollection<WalkDto> Walks { get; set; }
    }
}

