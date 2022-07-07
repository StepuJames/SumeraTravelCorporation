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
    public class AmenitiesDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAmenitiesService _amenitiesService;

        public AmenitiesDtoesController(ApplicationDbContext context, IMapper mapper, IAmenitiesService amenitiesService)
        {
            _context = context;
            _mapper = mapper;
            _amenitiesService = amenitiesService;
        }
            
        // GET: api/AmenitiesDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenitiesDto>>> GetAmenitiesDto()
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            // return await _context.AmenitiesDto.ToListAsync();
            var ameniteisDto = await _amenitiesService.GetAllAsync();
            return Ok(ameniteisDto);
        }

        // GET: api/AmenitiesDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenitiesDto>> GetAmenitiesDto(int id)
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            //var amenitiesDto = await _context.AmenitiesDto.FindAsync(id);
            var amenitiesDto = await _amenitiesService.GetByIdAsync(id);


            if (amenitiesDto == null)
            {
                return NotFound();
            }

            return amenitiesDto;
        }

        // PUT: api/AmenitiesDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenitiesDto(int id, AmenitiesDto amenitiesDto)
        {
             
            await _amenitiesService.Update(amenitiesDto);

            return NoContent();

        }

        // POST: api/AmenitiesDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AmenitiesDto>> PostAmenitiesDto(AmenitiesDto amenitiesDto)
        {
          if (_context.Amenities == null)
          {
              return Problem("Entity set 'ApplicationDbContext.AmenitiesDto'  is null.");
          }
             await _amenitiesService.CreateAsync(amenitiesDto);

            return CreatedAtAction("GetAmenitiesDto", new { id = amenitiesDto.Id }, amenitiesDto);
        }

        // DELETE: api/AmenitiesDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenitiesDto(int id)
        {
            if (_context.Amenities == null)
            {
                return NotFound();
            }
            
            await _amenitiesService.DeleteAsync(id);
            return NoContent();
        }

         
    }
}
