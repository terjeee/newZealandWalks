using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using newZealandWalks.API.CustomActionFilters;
using newZealandWalks.API.Models.Domain;
using newZealandWalks.API.Models.DTO;
using newZealandWalks.API.Repositories;

namespace newZealandWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        // create Walk
        // POST /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> WalkCreateAsync([FromBody] WalkAddDTO walkAddDTO)
        {
            // map DTO to DM
            var walkDM = mapper.Map<Walk>(walkAddDTO);

            // inject into DB
            walkDM = await walkRepository.WalkCreateAsync(walkDM);

            // map DM to 
            return Ok(mapper.Map<WalkDTO>(walkDM));

        }

        // api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> WalkGetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {

            var walksDM = await walkRepository.WalkGetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true);

            var walksDTO = mapper.Map<List<WalkDTO>>(walksDM);

            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> WalkGetByIdAsync([FromRoute] Guid id)
        {
            var walkDM = await walkRepository.WalkGetByIdAsync(id);

            if (walkDM == null) { return NotFound(); }

            var walkDTO = mapper.Map<WalkDTO>(walkDM);

            return Ok(walkDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> WalkUpdateAsync([FromRoute] Guid id, [FromBody] WalkUpdateDTO walkUpdateDTO)
        {
            if (ModelState.IsValid)
            {

                var walkDM = mapper.Map<Walk>(walkUpdateDTO);

                walkDM = await walkRepository.WalkUpdateAsync(id, walkDM);

                if (walkDM == null) { return NotFound(); }

                return Ok(mapper.Map<WalkDTO>(walkDM));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> WalkDeleteAsync([FromRoute] Guid id)
        {
            var deletedWalkDM = await walkRepository.WalkDeleteAsync(id);

            if (deletedWalkDM == null) { return NotFound(); }

            return Ok(mapper.Map<WalkDTO>(deletedWalkDM));
        }
    }
}
