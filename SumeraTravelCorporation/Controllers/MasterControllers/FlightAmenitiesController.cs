using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Controllers.MasterControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightAmenitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightAmenitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightAmenities>>> GetFlightAmenities()
        {
            if (_context.FlightAmenities == null)
            {
                return NotFound();
            }
            return await _context.FlightAmenities.ToListAsync();
        }

        // GET: api/FlightAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightAmenities>> GetFlightAmenities(int id)
        {
            if (_context.FlightAmenities == null)
            {
                return NotFound();
            }
            var flightAmenities = await _context.FlightAmenities.FindAsync(id);

            if (flightAmenities == null)
            {
                return NotFound();
            }

            return flightAmenities;
        }

        // PUT: api/FlightAmenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightAmenities(int id, FlightAmenities flightAmenities)
        {
            if (id != flightAmenities.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightAmenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightAmenitiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FlightAmenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightAmenities>> PostFlightAmenities(FlightAmenities flightAmenities)
        {
            if (_context.FlightAmenities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FlightAmenities'  is null.");
            }
            _context.FlightAmenities.Add(flightAmenities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightAmenities", new { id = flightAmenities.Id }, flightAmenities);
        }

        // DELETE: api/FlightAmenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightAmenities(int id)
        {
            if (_context.FlightAmenities == null)
            {
                return NotFound();
            }
            var flightAmenities = await _context.FlightAmenities.FindAsync(id);
            if (flightAmenities == null)
            {
                return NotFound();
            }

            _context.FlightAmenities.Remove(flightAmenities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightAmenitiesExists(int id)
        {
            return (_context.FlightAmenities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
