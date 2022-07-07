using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.MasterModels;

namespace SumeraTravelCorporation.Controllers.MasterControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelClassesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TravelClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TravelClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelClass>>> GetTravelClass()
        {
            if (_context.TravelClass == null)
            {
                return NotFound();
            }
            return await _context.TravelClass.ToListAsync();
        }

        // GET: api/TravelClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelClass>> GetTravelClass(int id)
        {
            if (_context.TravelClass == null)
            {
                return NotFound();
            }
            var travelClass = await _context.TravelClass.FindAsync(id);

            if (travelClass == null)
            {
                return NotFound();
            }

            return travelClass;
        }

        // PUT: api/TravelClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelClass(int id, TravelClass travelClass)
        {
            if (id != travelClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(travelClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelClassExists(id))
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

        // POST: api/TravelClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelClass>> PostTravelClass(TravelClass travelClass)
        {
            if (_context.TravelClass == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TravelClass'  is null.");
            }
            _context.TravelClass.Add(travelClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelClass", new { id = travelClass.Id }, travelClass);
        }

        // DELETE: api/TravelClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelClass(int id)
        {
            if (_context.TravelClass == null)
            {
                return NotFound();
            }
            var travelClass = await _context.TravelClass.FindAsync(id);
            if (travelClass == null)
            {
                return NotFound();
            }

            _context.TravelClass.Remove(travelClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelClassExists(int id)
        {
            return (_context.TravelClass?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
