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
    public class FlightDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFlightServices _flightService;

        public FlightDtoesController(ApplicationDbContext context, IMapper mapper, IFlightServices flightServices)
        {
            _context = context;
            _mapper = mapper;
            _flightService = flightServices;
        }

        // GET: api/FlightDtoes
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlightDto()
        {
          if (_context.Flight == null)
          {
              return NotFound();
          }
            //return await _context.FlightDto.ToListAsync();
            var flightDto = await _flightService.GetAllAsync();
            return Ok(flightDto);
        }

        // GET: api/FlightDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDto>> GetFlightDto(int id)
        {
          if (_context.Flight == null)
          {
              return NotFound();
          }
            //var flightDto = await _context.FlightDto.FindAsync(id);
            var flightDto = await _flightService.GetByIdAsync(id);

            if (flightDto == null)
            {
                return NotFound();
            }

            return flightDto;
        }

        // PUT: api/FlightDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightDto(int id, FlightDto flightDto)
        {
             //var flight = await _flightService.GetByIdAsync(id);
            await _flightService.Update(flightDto);

            return NoContent();
        }

        // POST: api/FlightDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightDto>> PostFlightDto(FlightDto flightDto)
        {
          if (_context.Flight == null)
          {
              return Problem("Entity set 'ApplicationDbContext.FlightDto'  is null.");
          }
             await _flightService.CreateAsync(flightDto);
           

            return CreatedAtAction("GetFlightDto", new { id = flightDto.Id }, flightDto);
        }

        // DELETE: api/FlightDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightDto(int id)
        {
            if (_context.Flight == null)
            {
                return NotFound();
            }
            var flightDto = await _context.Flight.FindAsync(id);
            if (flightDto == null)
            {
                return NotFound();
            }

           await _flightService.DeleteAsync(id);

            return NoContent();
        }

        private bool FlightDtoExists(int id)
        {
            return (_context.Flight?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
