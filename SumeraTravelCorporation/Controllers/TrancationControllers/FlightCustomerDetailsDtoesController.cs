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
    public class FlightCustomerDetailsDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFlightCustomerDetailsServices _flightCustomerDetailsServices;


        public FlightCustomerDetailsDtoesController(ApplicationDbContext context, IMapper mapper ,IFlightCustomerDetailsServices flightCustomerDetailsServices )
        {
            _context = context;
            _mapper = mapper;
            _flightCustomerDetailsServices = flightCustomerDetailsServices;
        }

        // GET: api/FlightCustomerDetailsDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightCustomerDetailsDto>>> GetFlightCustomerDetailsDto()
        {

            // return await _context.FlightCustomerDetailsDto.ToListAsync();
            var flightCustomerDetailsDto = await _flightCustomerDetailsServices.GetAllAsync();
            return flightCustomerDetailsDto;
        }

        // GET: api/FlightCustomerDetailsDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightCustomerDetailsDto>> GetFlightCustomerDetailsDto(int id)
        {
           
            //var flightCustomerDetailsDto = await _context.FlightCustomerDetailsDto.FindAsync(id);

            var flightCustomerDetailsDto = await _flightCustomerDetailsServices.GetByIdAsync(id);

            if (flightCustomerDetailsDto == null)
            {
                return NotFound();
            }

            return flightCustomerDetailsDto;
        }

        // PUT: api/FlightCustomerDetailsDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightCustomerDetailsDto(int id, FlightCustomerDetailsDto flightCustomerDetailsDto)
        {
            await _flightCustomerDetailsServices.UpdateAsync(flightCustomerDetailsDto);
            return NoContent();
        }

        // POST: api/FlightCustomerDetailsDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightCustomerDetailsDto>> PostFlightCustomerDetailsDto(FlightCustomerDetailsDto flightCustomerDetailsDto)
        {

            await _flightCustomerDetailsServices.CreateAsync(flightCustomerDetailsDto);
            return CreatedAtAction("GetFlightCustomerDetailsDto", new { id = flightCustomerDetailsDto.Id }, flightCustomerDetailsDto);
        }

        // DELETE: api/FlightCustomerDetailsDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightCustomerDetailsDto(int id)
        {
            await _flightCustomerDetailsServices.DeleteAsync(id);

            return NoContent();
        }

        
    }
}
