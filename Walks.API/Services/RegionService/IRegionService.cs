using Walks.API.Models;
using Walks.API.Models.Dtos;

namespace Walks.API.Services.RegionService
{
	public interface IRegionService
	{
        Task<ServiceResponse<RegionDto>> CreateRegionAsync(RegionCreateDto regionCreateDto);
        Task<ServiceResponse<List<RegionDto>>> GetAllRegionsAsync();
        Task<ServiceResponse<RegionDto>> GetRegionByIdAsync(int id);
        Task<int>GetRegionIdByGuidAsync(Guid Guid);
        Task<ServiceResponse<RegionDto>> SoftDeleteRegionAsync(int id);
        Task<ServiceResponse<RegionDto>> UpdateRegionAsync(RegionUpdateDto regionUpdateDto);

    }
}

