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
    public class HotelAmenitiesLinkDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHotelAmenitiesLinkService _hotelAmenitiesLinkService;


        public HotelAmenitiesLinkDtoesController(ApplicationDbContext context,IMapper mapper, IHotelAmenitiesLinkService hotelAmenitiesLinkServices)
        {
            _context = context;
            _mapper = mapper;
            _hotelAmenitiesLinkService = hotelAmenitiesLinkServices;
        }

        // GET: api/HotelAmenitiesLinkDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelAmenitiesLinkDto>>> GetHotelAmenitiesLinkDto()
        {
          if (_context.HotelAmenitiesLink == null)
          {
              return NotFound();
          }
            // return await _context.HotelAmenitiesLinkDto.ToListAsync();
            var hotelAmenitiesLink = await _hotelAmenitiesLinkService.GetAllAsync();
            return Ok(hotelAmenitiesLink);
        }

        // GET: api/HotelAmenitiesLinkDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelAmenitiesLinkDto>> GetHotelAmenitiesLinkDto(int id)
        {
          if (_context.HotelAmenitiesLink == null)
          {
              return NotFound();
          }
            //var hotelAmenitiesLinkDto = await _context.HotelAmenitiesLinkDto.FindAsync(id);
            var hotelAmenitiesLinkDto = await _hotelAmenitiesLinkService.GetByIdAsync(id);

            if (hotelAmenitiesLinkDto == null)
            {
                return NotFound();
            }

            return hotelAmenitiesLinkDto;
        }

        // PUT: api/HotelAmenitiesLinkDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAmenitiesLinkDto(int id, HotelAmenitiesLinkDto hotelAmenitiesLinkDto)
        {
             await _hotelAmenitiesLinkService.Update(hotelAmenitiesLinkDto);

            return NoContent();
        }

        // POST: api/HotelAmenitiesLinkDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelAmenitiesLinkDto>> PostHotelAmenitiesLinkDto(HotelAmenitiesLinkDto hotelAmenitiesLinkDto)
        {
          if (_context.HotelAmenitiesLink == null)
          {
              return Problem("Entity set 'ApplicationDbContext.HotelAmenitiesLinkDto'  is null.");
          }
            //_context.HotelAmenitiesLinkDto.Add(hotelAmenitiesLinkDto);

          await _hotelAmenitiesLinkService.CreateAsync(hotelAmenitiesLinkDto);

             

            return CreatedAtAction("GetHotelAmenitiesLinkDto", new { id = hotelAmenitiesLinkDto.Id }, hotelAmenitiesLinkDto);
        }

        // DELETE: api/HotelAmenitiesLinkDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAmenitiesLinkDto(int id)
        {
            if (_context.HotelAmenitiesLink == null)
            {
                return NotFound();
            }
           await _hotelAmenitiesLinkService.DeleteAsync(id);

            return NoContent();
        }

        private bool HotelAmenitiesLinkDtoExists(int id)
        {
            return (_context.HotelAmenitiesLink?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
