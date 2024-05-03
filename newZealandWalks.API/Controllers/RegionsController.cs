using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newZealandWalks.API.Data;
using newZealandWalks.API.Models.Domain;
using newZealandWalks.API.Models.DTO;
using System.Security.Cryptography.X509Certificates;

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
            // get data from database - domain model
            var regionsDM = dbContext.Regions.ToList();

            // map/convert DOMAIN MODEL to DTO
            var regionsDTO = new List<RegionDTO>();
            foreach (var regionDM in regionsDM)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = regionDM.Id,
                    Code = regionDM.Code,
                    Name = regionDM.Name,
                    RegionImageUrl = regionDM.RegionImageUrl,
                });
            };

            // return DTO
            return Ok(regionsDTO);
        }

        // GET region/(id)

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id); // .Find(id) kan bare brukes med id
            var regionDM = dbContext.Regions.FirstOrDefault(regionItem => regionItem.Id == id); // funker fordi vi passer id inn med [Route("{id:Guid}")]

            if (regionDM == null)
            {
                return NotFound();
            }

            // map/convert DM -> DTO
            var regionDTO = new RegionDTO
            {
                Id = regionDM.Id,
                Code = regionDM.Code,
                Name = regionDM.Name,
                RegionImageUrl = regionDM.RegionImageUrl,
            };

            return Ok(regionDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegionAddRequestDTO addRegionRequestDTO)
        {
            // map/convert DTO to DM
            var regionDM = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl,
            };

            // use DM to create Region in DM
            dbContext.Regions.Add(regionDM);
            dbContext.SaveChanges();

            // map DM back to DTO (safety concerns)
            var regionDTO = new RegionDTO
            {
                Id = regionDM.Id,
                Code = regionDM.Code,
                Name = regionDM.Name,
                RegionImageUrl = regionDM.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }
    }
}
