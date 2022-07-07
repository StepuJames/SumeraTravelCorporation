using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.TrancationServices;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Controllers.TrancationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightScheduleDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFlightScheduleServices _filghtScheduleService;

        public FlightScheduleDtoesController(ApplicationDbContext context, IMapper mapper, IFlightScheduleServices flightScheduleServices)
        {
            _context = context;
            _mapper = mapper;
            _filghtScheduleService = flightScheduleServices;
        }

        // GET: api/FlightScheduleDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightScheduleDto>>> GetFlightScheduleDto()
        {

            //return await _context.FlightScheduleDto.ToListAsync();
            var flightScheduleDto = await _filghtScheduleService.GetAllAsync();
            return flightScheduleDto;
        }

        // GET: api/FlightScheduleDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightScheduleDto>> GetFlightScheduleDto(int id)
        {

            //var flightScheduleDto = await _context.FlightScheduleDto.FindAsync(id);
            var flightScheduleDto = await _filghtScheduleService.GetByIdAsync(id);

            if (flightScheduleDto == null)
            {
                return NotFound();
            }

            return flightScheduleDto;
        }

        // PUT: api/FlightScheduleDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightScheduleDto(int id, FlightScheduleDto flightScheduleDto)
        {
           await _filghtScheduleService.UpdateAsync(flightScheduleDto);


            return NoContent();
        }

        // POST: api/FlightScheduleDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightScheduleDto>> PostFlightScheduleDto(FlightScheduleDto flightScheduleDto)
        {
            await _filghtScheduleService.CreateAsync(flightScheduleDto);


            return CreatedAtAction("GetFlightScheduleDto", new { id = flightScheduleDto.Id }, flightScheduleDto);
        }

        // DELETE: api/FlightScheduleDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightScheduleDto(int id)
        {
            await _filghtScheduleService.DeleteAsync(id);   

            return NoContent();
        }

      
    }
}
