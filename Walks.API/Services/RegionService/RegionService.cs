using AutoMapper;
using Walks.API.Data;
using Walks.API.Models.Domain;
using Walks.API.Models.Dtos;
using Walks.API.Repositories;

namespace Walks.API.Services.RegionService
{
	public class RegionService : IRegionService
	{
        private readonly IRegionRepository _repository;
        private readonly IMapper _mapper;

        public RegionService(IRegionRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<RegionDto>> CreateRegionAsync(RegionCreateDto regionCreateDto)
        {
            ServiceResponse<RegionDto> _response = new();

            try
            {
                if (await _repository.RegionExistsAsync(regionCreateDto.RegionName))
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.State = ValidStates.Exists;
                }

                Region _newRegion = new()
                {
                    GUID = Guid.NewGuid(),
                    RegionName = regionCreateDto.RegionName,
                    Code = regionCreateDto.Code,
                    CreatedDate = DateTimeOffset.UtcNow,
                    IsClosed = false,
                    IsDeleted = false
                };

                if (!await _repository.CreateRegionAsync(_newRegion))
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.State = ValidStates.Repository;

                    return _response;
                }

                _response.Success = true;
                _response.Data = _mapper.Map<RegionDto>(_newRegion);
                _response.State = ValidStates.Created;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.State = ValidStates.Error;
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<RegionDto>> SoftDeleteRegionAsync(int id)
        {
            ServiceResponse<RegionDto> _response = new();

            try
            {
                var _exists = await _repository.RegionExistsAsync(id);

                if (_exists == false)
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.State = ValidStates.NotFound;

                    return _response;
                }

                if (!await _repository.SoftDeleteRegionAsync(id))
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.State = ValidStates.Repository;

                    return _response;
                }

                _response.Success = true;
                _response.State = ValidStates.SoftDeleted;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.State = ValidStates.Error;
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<RegionDto>> GetRegionByIdAsync(int id)
        {
            ServiceResponse<RegionDto> _response = new();

            try
            {
                var _region = await _repository.GetRegionByIdAsync(id);

                if (_region == null)
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.State = ValidStates.NotFound;

                    return _response;
                }

                _response.Success = true;
                _response.State = ValidStates.OK;
                _response.Data = _mapper.Map<RegionDto>(_region);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.State = ValidStates.Error;
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<List<RegionDto>>> GetAllRegionsAsync()
        {
            ServiceResponse<List<RegionDto>> _response = new();

            try
            {
                var _regions = await _repository.GetRegionsAsync();

                if (_regions == null)
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.Error = "Failed to retrieve any Region records.";
                    _response.State = ValidStates.Repository;

                    return _response;
                }

                List<Region> _regionsDto = new();

                _response.Success = true;
                _response.State = ValidStates.OK;
                _response.Data = _regions.Select(r => _mapper.Map<RegionDto>(r)).ToList();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.State = ValidStates.Error;
                _response.Data = null;
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<RegionDto>> UpdateRegionAsync(RegionUpdateDto regionUpdateDto)
        {
            ServiceResponse<RegionDto> _response = new();

            try
            {
                var _regionExists = await _repository.GetRegionByGuidAsync(regionUpdateDto.GUID);

                if (_regionExists == null)
                {
                    _response.Success = false;
                    _response.State = ValidStates.NotFound;
                    _response.Data = null;

                    return _response;
                }

                _regionExists.RegionName = regionUpdateDto.RegionName;
                _regionExists.Code = regionUpdateDto.Code;
                _regionExists.RegionImgUrl = regionUpdateDto.RegionImgUrl;
                _regionExists.IsClosed = regionUpdateDto.IsClosed;
                _regionExists.IsDeleted = regionUpdateDto.IsDeleted;

                if (!await _repository.UpdateRegionAsync(_regionExists))
                {
                    _response.Success = false;
                    _response.State = ValidStates.Repository;
                    _response.Data = null;

                    return _response;
                }

                _response.Success = true;
                _response.State = ValidStates.Updated;
                _response.Data = _mapper.Map<RegionDto>(_regionExists);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.State = ValidStates.Error;
                _response.Data = null;
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }
    }
}

