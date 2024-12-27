using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        [HttpGet]

        public IActionResult GetAll()
        {

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AL",
                    RegionImageURL = "https://images.pexels.com/photos/2072264/pexels-photo-2072264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"

                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Buckland",
                    Code = "BL",
                    RegionImageURL = "https://images.pexels.com/photos/2072264/pexels-photo-2072264.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"

                }
            };

            return Ok(regions);
        }
    }
}
