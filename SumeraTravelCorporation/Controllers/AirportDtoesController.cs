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

namespace SumeraTravelCorporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAirportServices _airportService;

        public AirportDtoesController(ApplicationDbContext context,IMapper mapper, IAirportServices airportServices)
        {  
            _context = context;
            _mapper = mapper;
            _airportService = airportServices;
        }

        // GET: api/AirportDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportDto>>> GetAirportDto()
        {
          if (_context.Airport == null)
          {
              return NotFound();
          }
           // return await _context.AirportDto.ToListAsync();
           var airportDto = await _airportService.GetAllAsync();
            return Ok(airportDto);
        }

        // GET: api/AirportDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportDto>> GetAirportDto(int id)
        {
          if (_context.Airport == null)
          {
              return NotFound();
          }
            //var airportDto = await _context.AirportDto.FindAsync(id);
            var airportDto = await _airportService.GetByIdAsync(id);


            if (airportDto == null)
            {
                return NotFound();
            }

            return airportDto;
        }

        // PUT: api/AirportDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirportDto(int id, AirportDto airportDto)
        {
            await _airportService.Update(airportDto);

            return NoContent();

        }

        // POST: api/AirportDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirportDto>> PostAirportDto(AirportDto airportDto)
        {
          if (_context.Airport == null)
          {
              return Problem("Entity set 'ApplicationDbContext.AirportDto'  is null.");
          }
             await _airportService.CreateAsync(airportDto);

            return CreatedAtAction("GetAirportDto", new { id = airportDto.Id }, airportDto);
        }

        // DELETE: api/AirportDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirportDto(int id)
        {
            if (_context.Airport == null)
            {
                return NotFound();
            }
             await _airportService.DeleteAsync(id);

            return NoContent();
        }

        private bool AirportDtoExists(int id)
        {
            return (_context.Airport?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
