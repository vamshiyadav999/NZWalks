using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTOs;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    //https://localhostxyz/api/regions
    [Route("api/[controller]")]
    [ApiController]    
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        // Get All Regions
        // Get: https://localhost:portnumber/api/regions
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            // Get data from the database - Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Map Domain models to DTOs
            //var regionsDto = new List<RegionDto>();
            //foreach (var region in regions)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });

            //}

            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
            //Return DTOs
            return Ok(regionsDto);
        }
            //GET method
            //Retrieving a region based on id

            [HttpGet]
            [Route("{id:Guid}")]
            public async Task<IActionResult> GetById([FromRoute] Guid id)
            {
                var regions = await regionRepository. GetByIDAsync(id);

                if (regions == null)
                {
                    return NotFound();
                }
                //var regionDto = new RegionDto
                //{
                //    Id = regions.Id,
                //    Name = regions.Name,
                //    Code = regions.Code,
                //    RegionImageUrl = regions.RegionImageUrl,
                //};
                var regionDto = mapper.Map<RegionDto>(regions);
                // Return DTO back to the Client
                return Ok(regionDto);

            }
        //POST METHOD
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or convert a DTO Model to Domain Model

            //var regionsDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl
            //};

            var regionsDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            regionsDomainModel = await regionRepository.CreateAsync(regionsDomainModel);

            //Map the Domain Model back to DTO
            //var regionDTO = new RegionDto
            //{
            //    Id = regionsDomainModel.Id,
            //    Code = regionsDomainModel.Code,
            //    Name = regionsDomainModel.Name,
            //    RegionImageUrl = regionsDomainModel.RegionImageUrl
            //};
            var regionDto = mapper.Map<RegionDto>(regionsDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        // Update Method
        //// Update: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Map DTO to a Domain Model
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            //};
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO
            //var regionDto = new RegionDto
            //{
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

        // Delete Menthod
        // Delete : https://localhost:portnumber/api/regions/{id}
        
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            // Delete Region
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }
    }

} 
