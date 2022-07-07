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
    public class AirlineDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAirlineServices _airlineService;
        private readonly ILogger<AirlineDtoesController> _logger;

        public AirlineDtoesController(ApplicationDbContext context, IMapper mapper, IAirlineServices airlineService,ILogger<AirlineDtoesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _airlineService = airlineService;
            _logger = logger;
        }

       

        // GET: api/AirlineDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineDto>>> GetAirlineDto()
        {
          if (_context.Airline == null)
          {
              return NotFound();
          }
            //return await _context.AirlineDto.ToListAsync();
            var airlineDto = await _airlineService.GetAllAsync();
            return Ok(airlineDto);
        }

        // GET: api/AirlineDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineDto>> GetAirlineDto(int id)
        {
          if (_context.Airline == null)
          {
              return NotFound();
          }
            //var airlineDto = await _context.AirlineDto.FindAsync(id);
            var airlineDto = await _airlineService.GetByIdAsync(id);

            if (airlineDto == null)
            {
                return NotFound();
            }

            return airlineDto;
        }

        // PUT: api/AirlineDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirlineDto(int id, AirlineDto airlineDto)
        {
            await _airlineService.Update(airlineDto);

            return NoContent();
        }

        // POST: api/AirlineDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirlineDto>> PostAirlineDto([FromForm]AirlineDto airlineDto)
        {
          if (_context.Airline == null)
          {
              return Problem("Entity set 'ApplicationDbContext.AirlineDto'  is null.");
          }
            await  _airlineService.CreateAsync(airlineDto);

            return CreatedAtAction("GetAirlineDto", new { id = airlineDto.Id }, airlineDto);
        }

        // DELETE: api/AirlineDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirlineDto(int id)
        {
            if (_context.Airline == null)
            {
                return NotFound();
            }
              
            await _airlineService.DeleteAsync(id);
            return NoContent();
        }

         
    }
}
