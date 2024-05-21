using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newZealandWalks.API.Data;
using newZealandWalks.API.Models.Domain;
using newZealandWalks.API.Models.DTO;
using newZealandWalks.API.Repositories;
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
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(newZealandWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: https://localhost:1234/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // get data from database - domain model
            // var regionsDM = await dbContext.Regions.ToListAsync();
            var regionsDM = await regionRepository.AsyncGetAll();

            // map/convert DOMAIN MODEL to DTO
            //var regionsDTO = new List<RegionDTO>();
            //foreach (var regionDM in regionsDM)
            //{
            //    regionsDTO.Add(new RegionDTO()
            //    {
            //        Id = regionDM.Id,
            //        Code = regionDM.Code,
            //        Name = regionDM.Name,
            //        RegionImageUrl = regionDM.RegionImageUrl,
            //    });
            //};

            // map DM to DTO
            var regionsDTO = mapper.Map<List<RegionDTO>>(regionsDM);

            // return DTO
            return Ok(regionsDTO);
        }

        // GET region/(id)

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id); // .Find(id) kan bare brukes med id
            // var regionDM = await dbContext.Regions.FirstOrDefaultAsync(regionItem => regionItem.Id == id); // funker fordi vi passer id inn med [Route("{id:Guid}")]
            var regionDM = await regionRepository.AsyncGetById(id);

            if (regionDM == null) { return NotFound(); }

            // map/convert DM -> DTO
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDM.Id,
            //    Code = regionDM.Code,
            //    Name = regionDM.Name,
            //    RegionImageUrl = regionDM.RegionImageUrl,
            //};

            // map DM to DTO
            var regionDTO = mapper.Map<RegionDTO>(regionDM);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegionAddRequestDTO addRegionRequestDTO)
        {
            // map/convert DTO to DM
            //var regionDM = new Region
            //{
            //    Code = addRegionRequestDTO.Code,
            //    Name = addRegionRequestDTO.Name,
            //    RegionImageUrl = addRegionRequestDTO.RegionImageUrl,
            //};

            var regionDM = mapper.Map<Region>(addRegionRequestDTO);

            // use DM to create Region in DM
            // await dbContext.Regions.AddAsync(regionDM);
            // await dbContext.SaveChangesAsync();
            regionDM = await regionRepository.AsyncCreate(regionDM);

            // map DM back to DTO (safety concerns)
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDM.Id,
            //    Code = regionDM.Code,
            //    Name = regionDM.Name,
            //    RegionImageUrl = regionDM.RegionImageUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDM);

            // CreatedAtAction = HTTP 201 (created)
            // nameo() = action
            // new {} = route values (parameters)
            // regionDTO = object created, returned as response
            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }

        // update region
        // PUT: https://localhost:port/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            // Map DTO to DM
            //var regionDM = new Region
            //{
            //    Code = updateRegionDTO.Code,
            //    Name = updateRegionDTO.Name,
            //    RegionImageUrl = updateRegionDTO.RegionImageUrl
            //};

            var regionDM = mapper.Map<Region>(updateRegionDTO);

            // check if region exists
            // var regionDM = await dbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
            regionDM = await regionRepository.AsyncUpdate(id, regionDM);

            if (regionDM == null) { return NotFound(); }

            // map DTO to DMN
            // regionDM.Code = updateRegionDTO.Code ?? regionDM.Code;
            // regionDM.Name = updateRegionDTO.Name ?? regionDM.Name;
            // regionDM.RegionImageUrl = updateRegionDTO.RegionImageUrl ?? regionDM.RegionImageUrl;


            // save changes to DB
            // regiomDM is a DM tracked from the database, the changes above in the mapping just needs to be saved
            // await dbContext.SaveChangesAsync();

            // convert DM to DTO for the response
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDM.Id,
            //    Code = regionDM.Code,
            //    Name = regionDM.Name,
            //    RegionImageUrl = regionDM.RegionImageUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDM);

            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // var region = await dbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
            var regionDM = await regionRepository.AsyncDelete(id);

            if (regionDM == null) { return NotFound(); }

            // dbContext.Regions.Remove(region);
            // await dbContext.SaveChangesAsync();

            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDM.Id,
            //    Code = regionDM.Code,
            //    Name = regionDM.Name,
            //    RegionImageUrl = regionDM.RegionImageUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDM);

            return Ok(regionDTO);
        }
    }
}
