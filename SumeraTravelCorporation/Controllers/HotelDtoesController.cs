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
    public class HotelDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHotelService _hotelService;

        public HotelDtoesController(ApplicationDbContext context,IMapper mapper,IHotelService hotelService)
        {
            _context = context;
            _mapper = mapper;
            _hotelService = hotelService;
        }

        // GET: api/HotelDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotelDto()
        {
          if (_context.Hotel == null)
          {
              return NotFound();
          }   
            //return await _context.HotelDto.ToListAsync();
            var hotelDto = await _hotelService.GetAllAsync();
            return Ok(hotelDto);
        }

        // GET: api/HotelDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotelDto(int id)
        {
          if (_context.Hotel == null)
          {
              return NotFound();
          }
            //var hotelDto = await _context.HotelDto.FindAsync(id);
            var hotelDto = await _hotelService.GetByIdAsync(id);

            if (hotelDto == null)
            {
                return NotFound();
            }

            return  hotelDto;
        }

        // PUT: api/HotelDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelDto(int id, HotelDto hotelDto)
        {
            await _hotelService.Update(hotelDto);

            return NoContent();
        }

        // POST: api/HotelDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDto>> PostHotelDto(HotelDto hotelDto)
        {
          if (_context.Hotel == null)
          {
              return Problem("Entity set 'ApplicationDbContext.HotelDto'  is null.");
          }
            await _hotelService.CreateAsync(hotelDto); 

            return CreatedAtAction("GetHotelDto", new { id = hotelDto.Id }, hotelDto);
        }

        // DELETE: api/HotelDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDto(int id)
        {
            if (_context.Hotel == null)
            {
                return NotFound();
            }
             await _hotelService.DeleteAsync(id);

            return NoContent();
        }

         
    }
}
