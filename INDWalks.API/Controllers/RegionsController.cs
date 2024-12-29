using AutoMapper;
using INDWalks.API.Data;
using INDWalks.API.Models.Domain;
using INDWalks.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly INDWalksDbContext dbContext;
        private readonly IMapper mapper;

        public RegionsController(INDWalksDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var region = await dbContext.Regions.ToListAsync();
            if (region == null) {
                return NotFound();
            }

            return Ok(region);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(obj => obj.Id == id);

            if (region == null) { 
                return NotFound();
            }

            return Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestRegionDto requestRegion)
        {
            var regionDomain = mapper.Map<Region>(requestRegion);

            await dbContext.AddAsync(regionDomain);
            await dbContext.SaveChangesAsync();

            var responseDto = mapper.Map<ResponseRegionDto>(regionDomain);

            return Ok(responseDto);
        }
    }
}
