using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Services;

namespace SumeraTravelCorporation.Controllers.MasterControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;

        public CityDtoesController(ApplicationDbContext context,IMapper mapper, ICityService cityService )
        {
            _context = context;
            _mapper = mapper;
            _cityService = cityService;

        }

        // GET: api/CityDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCityDto()
        {
          if (_context.City == null)
          {
              return NotFound();
          }
          var cityDto = await _cityService.GetAllAsync();
            return Ok(cityDto);
        }

        // GET: api/CityDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCityDto(int id)
        {
          if (_context.City == null)
          {
              return NotFound();
          }
            //var cityDto = await _context.CityDto.FindAsync(id);
            var cityDto = await _cityService.GetByIdAsync(id);
            if (cityDto == null)
            {
                return NotFound();
            }

            return cityDto;
        }

        // PUT: api/CityDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityDto(int id, CityDto cityDto)
        {
           var city = await _cityService.GetByIdAsync(id);
            await _cityService.Update(cityDto);

            return NoContent();
        }

        // POST: api/CityDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityDto>> PostCityDto(CityDto cityDto)
        {
          if (_context.City == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CityDto'  is null.");
          }
             await _cityService.CreateAsync(cityDto);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityDto", new { id = cityDto.Id }, cityDto);
        }

        // DELETE: api/CityDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityDto(int id)
        {
            if (_context.City == null)
            {
                return NotFound();
            }
             await _cityService.DeleteAsync(id);
            return NoContent() ;
        }

       
    }
}
