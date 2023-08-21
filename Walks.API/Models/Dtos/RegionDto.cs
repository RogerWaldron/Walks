﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Walks.API.Models.Domain;

namespace Walks.API.Models.Dtos
{
	public class RegionDto
	{
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImgUrl { get; set; }
        public bool IsClosed { get; set; }

        // Foreign Key
        [Required]
        public int WalkId { get; set; }

        [ForeignKey("WalkId")]
        public WalkDto Walk { get; set; }
    }
}

