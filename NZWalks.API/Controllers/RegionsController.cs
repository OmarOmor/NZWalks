using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;
using System.Linq.Expressions;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var regionsDomain = await _regionRepository.GetAllAsync();

            var regionsDTO = new List<RegionDTO>();

            foreach (var regionDomain in regionsDomain)
            {
                regionsDTO.Add(new RegionDTO
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageURL = regionDomain.RegionImageURL,
                });
            }


            return Ok(regionsDTO);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var regionDomain = await _regionRepository.GetById(id);
            if(regionDomain == null)
            {
                return NotFound();
            }

            RegionDTO regionDTO = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageURL = regionDomain.RegionImageURL,
            };

            return Ok(regionDTO);

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomain = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageURL = addRegionRequestDTO.RegionImageURL,
            };

            regionDomain = await _regionRepository.CreateAsync(regionDomain);

            var regionDTO = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageURL = regionDomain.RegionImageURL,
            };


            return CreatedAtAction(nameof(GetById),new {id = regionDTO.Id },regionDTO);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomain = new Region
            {
                Name = updateRegionRequestDTO.Name,
                Code = updateRegionRequestDTO.Code,
                RegionImageURL = updateRegionRequestDTO.RegionImageURL,
            };

            regionDomain = await _regionRepository.UpdateAsync(id, regionDomain);

            if(regionDomain == null)
            {
                return NotFound();
            }



            var regionDTO = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageURL = regionDomain.RegionImageURL,
            };


            return Ok(regionDTO);
        }



        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.DeleteAsync(id);

            if( regionDomain == null)
            {
                return NotFound();
            }
            var regionDTO = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageURL = regionDomain.RegionImageURL,
            };
            return Ok(regionDTO);
        }
    }



}
