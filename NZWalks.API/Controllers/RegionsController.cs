﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var regionsDomain = await _regionRepository.GetAllAsync();

            var regionsDTO = _mapper.Map<List<RegionDTO>>(regionsDomain);

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

            //RegionDTO regionDTO = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageURL = regionDomain.RegionImageURL,
            //};
            var regionDTO = _mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionDTO);

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomain = _mapper.Map<Region>(addRegionRequestDTO);

            regionDomain = await _regionRepository.CreateAsync(regionDomain);


            var regionDTO = _mapper.Map<RegionDTO>(regionDomain);


            return CreatedAtAction(nameof(GetById),new {id = regionDTO.Id },regionDTO);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomain = _mapper.Map<Region>(updateRegionRequestDTO);

            regionDomain = await _regionRepository.UpdateAsync(id, regionDomain);

            if(regionDomain == null)
            {
                return NotFound();
            }



            var regionDTO = _mapper.Map<RegionDTO>(regionDomain);


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
            var regionDTO = _mapper.Map<RegionDTO>(regionDomain);

            return Ok(regionDTO);
        }
    }



}
