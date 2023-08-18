using Microsoft.AspNetCore.Mvc;
using Walks.API.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly WalksDbContext _dbContext;

        public RegionsController(WalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();

            return Ok(regions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetByid(Guid id)
        {
            var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
                return NotFound();

            return Ok(region);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

