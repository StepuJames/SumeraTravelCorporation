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
    public class HotelAmenitiesLinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelAmenitiesLinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelAmenitiesLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelAmenitiesLink>>> GetHotelAmenitiesLink()
        {
            if (_context.HotelAmenitiesLink == null)
            {
                return NotFound();
            }
            return await _context.HotelAmenitiesLink.ToListAsync();
        }

        // GET: api/HotelAmenitiesLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelAmenitiesLink>> GetHotelAmenitiesLink(int id)
        {
            if (_context.HotelAmenitiesLink == null)
            {
                return NotFound();
            }
            var hotelAmenitiesLink = await _context.HotelAmenitiesLink.FindAsync(id);

            if (hotelAmenitiesLink == null)
            {
                return NotFound();
            }

            return hotelAmenitiesLink;
        }

        // PUT: api/HotelAmenitiesLinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAmenitiesLink(int id, HotelAmenitiesLink hotelAmenitiesLink)
        {
            if (id != hotelAmenitiesLink.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelAmenitiesLink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelAmenitiesLinkExists(id))
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

        // POST: api/HotelAmenitiesLinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelAmenitiesLink>> PostHotelAmenitiesLink(HotelAmenitiesLink hotelAmenitiesLink)
        {
            if (_context.HotelAmenitiesLink == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HotelAmenitiesLink'  is null.");
            }
            _context.HotelAmenitiesLink.Add(hotelAmenitiesLink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelAmenitiesLink", new { id = hotelAmenitiesLink.Id }, hotelAmenitiesLink);
        }

        // DELETE: api/HotelAmenitiesLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAmenitiesLink(int id)
        {
            if (_context.HotelAmenitiesLink == null)
            {
                return NotFound();
            }
            var hotelAmenitiesLink = await _context.HotelAmenitiesLink.FindAsync(id);
            if (hotelAmenitiesLink == null)
            {
                return NotFound();
            }

            _context.HotelAmenitiesLink.Remove(hotelAmenitiesLink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelAmenitiesLinkExists(int id)
        {
            return (_context.HotelAmenitiesLink?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
