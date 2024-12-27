using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using System.Linq.Expressions;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;

        public RegionsController(NZWalksDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            var regionsDomain = _context.Regions.ToList();

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
        public IActionResult GetById([FromRoute]Guid id)
        {
            var regionDomain = _context.Regions.FirstOrDefault(x=> x.Id == id); 
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
        public IActionResult Create([FromBody]AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomain = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageURL = addRegionRequestDTO.RegionImageURL,
            };

            _context.Regions.Add(regionDomain);
            _context.SaveChanges();

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
        public IActionResult Update([FromRoute] Guid id, [FromBody]UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomain = _context.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomain == null)
            {
                return NotFound();
            }

            //Update the required data
            regionDomain.Code = updateRegionRequestDTO.Code;
            regionDomain.Name = updateRegionRequestDTO.Name;
            regionDomain.RegionImageURL = updateRegionRequestDTO.RegionImageURL;

            _context.SaveChanges();


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

        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomain = _context.Regions.FirstOrDefault(x => x.Id == id);

            if( regionDomain == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(regionDomain);
            _context.SaveChanges();


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
