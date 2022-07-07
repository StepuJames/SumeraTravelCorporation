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
    public class HotelRoomDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHotelRoomServices _hotelRoomServices;

        public HotelRoomDtoesController(ApplicationDbContext context, IMapper mapper, IHotelRoomServices hotelRoomServices)
        {
            _context = context;
            _mapper = mapper;
            _hotelRoomServices = hotelRoomServices;
        }

        // GET: api/HotelRoomDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDto>>> GetHotelRoomDto()
        {
          
           // return await _context.HotelRoomDto.ToListAsync();
           var hotelRoomDto = await _hotelRoomServices.GetAllAsync();
            return Ok(hotelRoomDto);
        }

        // GET: api/HotelRoomDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoomDto>> GetHotelRoomDto(int id)
        {
           

            //var hotelRoomDto = await _context.HotelRoomDto.FindAsync(id);

            var hotelRoomDto = await _hotelRoomServices.GetByIdAsync(id);
            if (hotelRoomDto == null)
            {
                return NotFound();
            }

            return hotelRoomDto;
        }

        // PUT: api/HotelRoomDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoomDto(int id, HotelRoomDto hotelRoomDto)
        {


            await _hotelRoomServices.Update(hotelRoomDto);

            return NoContent();
        }

        // POST: api/HotelRoomDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoomDto>> PostHotelRoomDto(HotelRoomDto hotelRoomDto)
        {

            await _hotelRoomServices.CreateAsync(hotelRoomDto);

            //return CreatedAtAction("GetHotelRoomDto", new { id = hotelRoomDto.Id }, hotelRoomDto);
            return Ok(hotelRoomDto);
        }

        // DELETE: api/HotelRoomDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRoomDto(int id)
        {
             
            await _hotelRoomServices.DeleteAsync(id);

            return NoContent();
        }

       
    }
}
