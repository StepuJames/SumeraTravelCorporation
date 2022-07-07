using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Controllers.MasterControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightAmenitiesLinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightAmenitiesLinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightAmenitiesLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightAmenitiesLink>>> GetFlightAmenitiesLink()
        {
            if (_context.FlightAmenitiesLink == null)
            {
                return NotFound();
            }
            return await _context.FlightAmenitiesLink.ToListAsync();
        }

        // GET: api/FlightAmenitiesLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightAmenitiesLink>> GetFlightAmenitiesLink(int id)
        {
            if (_context.FlightAmenitiesLink == null)
            {
                return NotFound();
            }
            var flightAmenitiesLink = await _context.FlightAmenitiesLink.FindAsync(id);

            if (flightAmenitiesLink == null)
            {
                return NotFound();
            }

            return flightAmenitiesLink;
        }

        // PUT: api/FlightAmenitiesLinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightAmenitiesLink(int id, FlightAmenitiesLink flightAmenitiesLink)
        {
            if (id != flightAmenitiesLink.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightAmenitiesLink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightAmenitiesLinkExists(id))
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

        // POST: api/FlightAmenitiesLinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightAmenitiesLink>> PostFlightAmenitiesLink(FlightAmenitiesLink flightAmenitiesLink)
        {
            if (_context.FlightAmenitiesLink == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FlightAmenitiesLink'  is null.");
            }
            _context.FlightAmenitiesLink.Add(flightAmenitiesLink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightAmenitiesLink", new { id = flightAmenitiesLink.Id }, flightAmenitiesLink);
        }

        // DELETE: api/FlightAmenitiesLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightAmenitiesLink(int id)
        {
            if (_context.FlightAmenitiesLink == null)
            {
                return NotFound();
            }
            var flightAmenitiesLink = await _context.FlightAmenitiesLink.FindAsync(id);
            if (flightAmenitiesLink == null)
            {
                return NotFound();
            }

            _context.FlightAmenitiesLink.Remove(flightAmenitiesLink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightAmenitiesLinkExists(int id)
        {
            return (_context.FlightAmenitiesLink?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
