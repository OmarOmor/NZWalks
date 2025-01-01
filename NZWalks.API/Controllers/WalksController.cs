using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalksRepository _walksRepository;
        private readonly IMapper _mapper;
        public WalksController(IMapper mapper,IWalksRepository walksRepository)
        {
            _mapper = mapper;
            _walksRepository = walksRepository;
        }

        // CREATE : Walk
        // POST : /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDTO addWalksReqDTO)
        {
            if(ModelState.IsValid)
            {
                var walkDomain = _mapper.Map<Walk>(addWalksReqDTO);

                await _walksRepository.CreateAsync(walkDomain);

                var walkDTO = _mapper.Map<WalksDTO>(walkDomain);

                return Ok(walkDTO);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        // GET : Walk
        // GET : /api/walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]string? filterOn, [FromQuery]string? filterQuery,
                            [FromQuery] string? sortBy, 
                            [FromQuery] bool? isAscending,
                            [FromQuery]int pageNumber = 1,
                            [FromQuery]int pageSize = 1000)
        {
            var walkDomainList = await _walksRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending ?? true,pageNumber,pageSize);

            var walkDTO_List = _mapper.Map<List<WalksDTO>>(walkDomainList);

            return Ok(walkDTO_List);
        }

        // GET : /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var walkDomain = await _walksRepository.GetByIdAsync(id);

            if(walkDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalksDTO>(walkDomain));
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkDTO updateWalkDTO)
        {
            if(ModelState.IsValid)
            {
                var walkDomain = _mapper.Map<Walk>(updateWalkDTO);

                walkDomain = await _walksRepository.UpdateAsync(id, walkDomain);

                if (walkDomain == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<WalksDTO>(walkDomain));
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deletedWalkDomain = await _walksRepository.Delete(id);

            if(deletedWalkDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalksDTO>(deletedWalkDomain));
        }


    }
}
