using System;
using Walks.API.Models;
using Walks.API.Models.Dtos;

namespace Walks.API.Services.RegionService
{
	public interface IRegionService
	{
		Task<ServiceResponse<List<RegionDto>>> GetRegions();
        Task<ServiceResponse<RegionDto>> GetRegionById(Guid id);
        Task<ServiceResponse<List<RegionDto>>> CreateRegion(RegionCreateDto regionCreateDto);
        Task<ServiceResponse<RegionDto>> UpdateRegion(RegionUpdateDto regionUpdateDto);
        Task<ServiceResponse<List<RegionDto>>> DeleteRegion(Guid id);
    }
}

