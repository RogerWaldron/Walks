﻿using System;
namespace Walks.API.Models.Dtos
{
	public class RegionDto
	{
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImgUrl { get; set; }
    }
}

