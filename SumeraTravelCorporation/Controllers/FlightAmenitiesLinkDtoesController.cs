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
    public class FlightAmenitiesLinkDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFlightAmenitiesLinkServices _flightAmenitiesLinkServices;

        public FlightAmenitiesLinkDtoesController(ApplicationDbContext context, IMapper mapper, IFlightAmenitiesLinkServices flightAmenitiesLinkServices)
        {
            _context = context;
            _mapper = mapper;
            _flightAmenitiesLinkServices = flightAmenitiesLinkServices;
        }

        // GET: api/FlightAmenitiesLinkDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightAmenitiesLinkDto>>> GetFlightAmenitiesLinkDto()
        {

            //return await _context.FlightAmenitiesLinkDto.ToListAsync();
            var flightAmenitiesLinkDto = await _flightAmenitiesLinkServices.GetAllAsync();
            return Ok(flightAmenitiesLinkDto);
        }

        // GET: api/FlightAmenitiesLinkDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightAmenitiesLinkDto>> GetFlightAmenitiesLinkDto(int id)
        {
           
           // var flightAmenitiesLinkDto = await _context.FlightAmenitiesLinkDto.FindAsync(id);
           var flightAmenitiesLinkDto = await _flightAmenitiesLinkServices.GetByIdAsync(id);

            if (flightAmenitiesLinkDto == null)
            {
                return NotFound();
            }
            
            return flightAmenitiesLinkDto;
        }

        // PUT: api/FlightAmenitiesLinkDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightAmenitiesLinkDto(int id, FlightAmenitiesLinkDto flightAmenitiesLinkDto)
        {
            await _flightAmenitiesLinkServices.Update(flightAmenitiesLinkDto);

            return NoContent();
        }

        // POST: api/FlightAmenitiesLinkDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightAmenitiesLinkDto>> PostFlightAmenitiesLinkDto(FlightAmenitiesLinkDto flightAmenitiesLinkDto)
        {
           
            await _flightAmenitiesLinkServices.CreateAsync(flightAmenitiesLinkDto); 
            return CreatedAtAction("GetFlightAmenitiesLinkDto", new { id = flightAmenitiesLinkDto.Id }, flightAmenitiesLinkDto);
        }

        // DELETE: api/FlightAmenitiesLinkDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightAmenitiesLinkDto(int id)
        {
            
             
            await _flightAmenitiesLinkServices.DeleteAsync(id); 
            return NoContent();
        }

        
    }
}
