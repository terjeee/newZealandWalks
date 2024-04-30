using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newZealandWalks.API.Data;
using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Controllers
{
    // https://localhost:1234/api/[controllers]
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly newZealandWalksDbContext dbContext;

        public RegionsController(newZealandWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET ALL REGIONS
        // GET: https://localhost:1234/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }

        // GET region/(id)

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id); // .Find(id) kan bare brukes med id
            var region = dbContext.Regions.FirstOrDefault(regionItem => regionItem.Id == id); // funker fordi vi passer id inn med [Route("{id:Guid}")]

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        } 
    }
}
