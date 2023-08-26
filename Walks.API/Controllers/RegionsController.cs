using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Data;
using Walks.API.Models.Dtos;
using Walks.API.Services;
using Walks.API.Services.RegionService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            this._regionService = regionService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RegionDto>))]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<RegionDto>> _response = await _regionService.GetAllRegionsAsync();

            return Ok(_response);
        }

        // GET api/values/5
        [HttpGet("{regionId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById(int regionId)
        {
            ServiceResponse<RegionDto> _response = await _regionService.GetRegionByIdAsync(regionId);

            if (_response.State == ValidStates.Error)
            {
                ModelState.AddModelError("", $"Service Error occurred when trying to get Region with id {regionId}");

                return BadRequest(ModelState);
            }

            if (_response.State == ValidStates.NotFound)
                return NotFound();

            return Ok(_response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RegionCreateDto regionCreateDto)
        {
            if (regionCreateDto == null ||
                !ModelState.IsValid)
                return BadRequest(ModelState);

            ServiceResponse<RegionDto> _response = await _regionService.CreateRegionAsync(regionCreateDto);


            if (_response.Success == false && _response.State == ValidStates.Repository)
            {
                ModelState.AddModelError("", $"Repository layer could not create region: {regionCreateDto}");

                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }


            if (_response.Success == false && _response.State == ValidStates.Error)
            {
                ModelState.AddModelError("", $"Service layer could not create region: {regionCreateDto}");

                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            if (_response.Success == false && _response.State == ValidStates.Exists)
            {
                return Ok(_response);
            }

            if(_response.Data == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);

            var _id = await _regionService.GetRegionIdByGuidAsync(_response.Data.GUID);

            return CreatedAtAction(nameof(GetById), new { regionId = _id }, _response);
        }

        // PUT api/values/5
        [HttpPut("{regionGuid:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid regionGuid, [FromBody]RegionUpdateDto regionUpdateDto)
        {
            if (regionUpdateDto == null ||
                regionGuid != regionUpdateDto.GUID ||
                !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceResponse<RegionDto> _response = await _regionService.UpdateRegionAsync(regionUpdateDto);

            if (_response.Success == false && _response.State == ValidStates.NotFound)
                return NotFound(_response);

            if (_response.Success == false && _response.State == ValidStates.Repository)
            {
                ModelState.AddModelError("", $"Repository Error occured when trying to update region {regionUpdateDto.GUID}");

                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            if (_response.Success == false && _response.State == ValidStates.Error)
            {
                ModelState.AddModelError("", $"Service Error occured when trying to update region {regionUpdateDto.GUID}");

                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return Ok(_response);
        }

        // DELETE api/values/5
        [HttpDelete("{regionId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int regionId)
        {
            ServiceResponse<RegionDto> _response = await _regionService.SoftDeleteRegionAsync(regionId);

            if (_response.Success == false && _response.State == ValidStates.NotFound)
            {
                ModelState.AddModelError("", "Region not found");

                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }

            if (_response.Success == false && _response.State == ValidStates.Repository)
            {
                ModelState.AddModelError("", $"Repository Error occurred when trying to delete region {regionId}");

                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            if (_response.Success == false && _response.State == ValidStates.Error)
            {
                ModelState.AddModelError("", $"Service Error occured when trying to delete region {regionId}");

                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }
    }
}

