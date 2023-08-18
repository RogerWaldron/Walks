using System;
namespace Walks.API.Models
{
	public class Walk
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double DistanceInKm { get; set; }
        public string? WalkImgUrl { get; set; }

        // Foreign Keys
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Nav
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}

