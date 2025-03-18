using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTOs;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        //CREATE WALK
        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to the Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);
             
            //Map the Domain model to DTO
            mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDomainModel); 
        }

        //GET ALL WALKS
       [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksModel = await walkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepository.GetByIDAsync(id);

            if (walksDomainModel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<WalkDto>(walksDomainModel));
            }  
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walksDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walksDomainModel = await walkRepository.UpdateAsync(id, walksDomainModel);

            if(walksDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walksDomainModel));
        }
    }
}
