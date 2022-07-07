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
    public class FlightAmenitiesDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFlightAmenitiesServices _flightAmenitiesService;

        public FlightAmenitiesDtoesController(ApplicationDbContext context, IMapper mapper, IFlightAmenitiesServices flightAmenitiesServices)
        {
            _context = context;
            _mapper = mapper;
            _flightAmenitiesService = flightAmenitiesServices;
        }

        // GET: api/FlightAmenitiesDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightAmenitiesDto>>> GetFlightAmenitiesDto()
        {
         
            //return await _context.FlightAmenitiesDto.ToListAsync();
            var flightAmenitiesDto = await _flightAmenitiesService.GetAllAsync();
            return Ok(flightAmenitiesDto);
        }

        // GET: api/FlightAmenitiesDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightAmenitiesDto>> GetFlightAmenitiesDto(int id)
        {
          
            //var flightAmenitiesDto = await _context.FlightAmenitiesDto.FindAsync(id);
            var flightAmenitiesDto = await _flightAmenitiesService.GetByIdAsync(id);


            if (flightAmenitiesDto == null)
            {
                return NotFound();
            }

            return flightAmenitiesDto;
        }
        
        // PUT: api/FlightAmenitiesDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightAmenitiesDto(int id, FlightAmenitiesDto flightAmenitiesDto)
        {
            await _flightAmenitiesService.Update(flightAmenitiesDto);
            return NoContent();
        }

        // POST: api/FlightAmenitiesDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightAmenitiesDto>> PostFlightAmenitiesDto(FlightAmenitiesDto flightAmenitiesDto)
        {
           
            await _flightAmenitiesService.CreateAsync(flightAmenitiesDto);

            return CreatedAtAction("GetFlightAmenitiesDto", new { id = flightAmenitiesDto.Id }, flightAmenitiesDto);
        }

        // DELETE: api/FlightAmenitiesDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightAmenitiesDto(int id)
        {
             
             await _flightAmenitiesService.DeleteAsync(id);

            return NoContent();
        }

     
    }
}
