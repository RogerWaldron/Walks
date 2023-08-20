using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.Dtos;
using Walks.API.Services;
using Walks.API.Services.RegionService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            this._regionService = regionService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _regionService.GetAllRegionsAsync());
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByid(int id)
        {
            return Ok(await _regionService.GetRegionByIdAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegionCreateDto regionCreateDto)
        {
            return Ok(await _regionService.CreateRegionAsync(regionCreateDto));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]RegionUpdateDto regionUpdateDto)
        {
            ServiceResponse<RegionDto> response = await _regionService.UpdateRegionAsync(regionUpdateDto);
            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<RegionDto> response = await _regionService.SoftDeleteRegionAsync(id);
            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }
    }
}

