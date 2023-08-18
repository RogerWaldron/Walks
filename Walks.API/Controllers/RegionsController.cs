using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Data;
using Walks.API.Models.Domain;
using Walks.API.Models.Dtos;
using Walks.API.Services.RegionService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _regionService.GetRegions());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(Guid id)
        {
            return Ok(await _regionService.GetRegionById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegionCreateDto regionCreateDto)
        {
            return Ok(await _regionService.CreateRegion(regionCreateDto));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]RegionUpdateDto regionUpdateDto)
        {
            return Ok(await _regionService.UpdateRegion(regionUpdateDto));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _regionService.DeleteRegion(id));
        }
    }
}

