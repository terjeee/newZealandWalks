﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
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
        public async Task<IActionResult> WalkCreateAsync([FromBody] WalkAddDTO walkAddDTO)
        {
            // map DTO to DM
            var walkDM = mapper.Map<Walk>(walkAddDTO);

            // inject into DB
            walkDM = await walkRepository.WalkCreateAsync(walkDM);

            // map DM to 
            return Ok(mapper.Map<WalkDTO>(walkDM));
        }

        [HttpGet]
        public async Task<IActionResult> WalkGetAllAsync()
        {
            var walksDM = await walkRepository.WalkGetAllAsync();

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
    }
}
