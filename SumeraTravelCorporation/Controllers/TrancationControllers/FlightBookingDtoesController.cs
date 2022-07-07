using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.TrancationServices;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Controllers.TrancationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightBookingDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFlightBookingServices _flightBookingServices;

        public FlightBookingDtoesController(ApplicationDbContext context, IMapper mapper, IFlightBookingServices flightBookingServices)
        {
            _context = context;
            _mapper = mapper;
            _flightBookingServices = flightBookingServices;
        }

        // GET: api/FlightBookingDtoes    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightBookingDto>>> GetFlightBookingDto()
        {

            //return await _context.FlightBookingDto.ToListAsync();
            var flightBookingDto = await _flightBookingServices.GetAllAsync();
            return flightBookingDto;

        }

        // GET: api/FlightBookingDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightBookingDto>> GetFlightBookingDto(int id)
        {
          
            //var flightBookingDto = await _context.FlightBookingDto.FindAsync(id);
            var flightBookingDto = await _flightBookingServices.GetByIdAsync(id);


            if (flightBookingDto == null)
            {
                return NotFound();
            }

            return flightBookingDto;
        }

        // PUT: api/FlightBookingDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightBookingDto(int id, FlightBookingDto flightBookingDto)
        {
             await _flightBookingServices.UpdateAsync(flightBookingDto);

            return NoContent();
        }

        // POST: api/FlightBookingDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightBookingDto>> PostFlightBookingDto(FlightBookingDto flightBookingDto)
        {
           await _flightBookingServices.CreateAsync(flightBookingDto);

            return CreatedAtAction("GetFlightBookingDto", new { id = flightBookingDto.Id }, flightBookingDto);
        }

        // DELETE: api/FlightBookingDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightBookingDto(int id)
        {
          await _flightBookingServices.DeleteAsync(id);

            return NoContent();
        }

        
    }
}
