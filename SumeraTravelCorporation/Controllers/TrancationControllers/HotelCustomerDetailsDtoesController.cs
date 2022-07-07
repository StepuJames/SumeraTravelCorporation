using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.TrancationServices;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Controllers.TrancationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelCustomerDetailsDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHotelCustomerDetailsServices _hotelCustomerDetailsServices;

        public HotelCustomerDetailsDtoesController(ApplicationDbContext context, IMapper mapper, IHotelCustomerDetailsServices hotelCustomerDetailsServices )
        {
            _context = context;
            _mapper = mapper;
            _hotelCustomerDetailsServices = hotelCustomerDetailsServices;
        }

        // GET: api/HotelCustomerDetailsDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelCustomerDetailsDto>>> GetHotelCustomerDetailsDto()
        {
           
            //return await _context.HotelCustomerDetailsDto.ToListAsync();
            var hotelCustomerDetailsDto = await _hotelCustomerDetailsServices.GetAllAsync();
            return hotelCustomerDetailsDto;
        }

        // GET: api/HotelCustomerDetailsDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelCustomerDetailsDto>> GetHotelCustomerDetailsDto(int id)
        {
            // var hotelCustomerDetailsDto = await _context.HotelCustomerDetailsDto.FindAsync(id);

            var hotelCustomerDetailsDto = await _hotelCustomerDetailsServices.GetByIdAsync(id);

            if (hotelCustomerDetailsDto == null)
            {
                return NotFound();
            }

            return hotelCustomerDetailsDto;
        }

        // PUT: api/HotelCustomerDetailsDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelCustomerDetailsDto(int id, HotelCustomerDetailsDto hotelCustomerDetailsDto)
        {

            await _hotelCustomerDetailsServices.UpdateAsync(hotelCustomerDetailsDto);
            return NoContent();
        }

        // POST: api/HotelCustomerDetailsDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelCustomerDetailsDto>> PostHotelCustomerDetailsDto(HotelCustomerDetailsDto hotelCustomerDetailsDto)
        {
            await _hotelCustomerDetailsServices.CreateAsync(hotelCustomerDetailsDto);

            return CreatedAtAction("GetHotelCustomerDetailsDto", new { id = hotelCustomerDetailsDto.Id }, hotelCustomerDetailsDto);
        }

        // DELETE: api/HotelCustomerDetailsDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelCustomerDetailsDto(int id)
        {
             
            await _hotelCustomerDetailsServices.DeleteAsync(id);    
            return NoContent();
        }

        
    }
}
