using AutoMapper;
using Walks.API.Models.Domain;
using Walks.API.Models.Dtos;

namespace Walks.API.Mappings
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<RegionCreateDto, Region>().ReverseMap();
            CreateMap<RegionUpdateDto, Region>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}

