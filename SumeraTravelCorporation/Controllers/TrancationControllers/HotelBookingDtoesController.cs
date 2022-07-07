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
    public class HotelBookingDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHotelBookingServices _hotelBookingServices;

        public HotelBookingDtoesController(ApplicationDbContext context, IMapper mapper, IHotelBookingServices hotelBookingServices)
        {
            _context = context;
            _mapper = mapper;
            _hotelBookingServices = hotelBookingServices;
        }

        // GET: api/HotelBookingDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelBookingDto>>> GetHotelBookingDto()
        {

            // return await _context.HotelBookingDto.ToListAsync();
            var hotelBookingDto = await _hotelBookingServices.GetAllAsync();
            return hotelBookingDto;
        }

        // GET: api/HotelBookingDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelBookingDto>> GetHotelBookingDto(int id)
        {

            //var hotelBookingDto = await _context.HotelBookingDto.FindAsync(id);
            var hotelBookingDto = await _hotelBookingServices.GetByIdAsync(id);


            if (hotelBookingDto == null)
            {
                return NotFound();
            }

            return hotelBookingDto;
        }

        // PUT: api/HotelBookingDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelBookingDto(int id, HotelBookingDto hotelBookingDto)
        {
            await _hotelBookingServices.UpdateAsync(hotelBookingDto);


            return NoContent();
        }

        // POST: api/HotelBookingDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelBookingDto>> PostHotelBookingDto(HotelBookingDto hotelBookingDto)
        {

            await _hotelBookingServices.CreateAsync(hotelBookingDto);
            return CreatedAtAction("GetHotelBookingDto", new { id = hotelBookingDto.Id }, hotelBookingDto);
        }

        // DELETE: api/HotelBookingDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelBookingDto(int id)
        {
            await _hotelBookingServices.DeleteAsync(id);

            return NoContent();
        }

        
    }
}
