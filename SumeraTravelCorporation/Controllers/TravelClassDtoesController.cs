using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;  
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Services;

namespace SumeraTravelCorporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelClassDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITravelClassServices _travelClassServices;


        public TravelClassDtoesController(ApplicationDbContext context, IMapper mapper, ITravelClassServices travelClassServices)
        {
            _context = context;
            _mapper = mapper;
            _travelClassServices = travelClassServices;
        }

        // GET: api/TravelClassDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelClassDto>>> GetTravelClassDto()
        {
           
           // return await _context.TravelClassDto.ToListAsync();

            var travelClassDto = await  _travelClassServices.GetAllAsync();
            return Ok(travelClassDto);
        }

        // GET: api/TravelClassDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelClassDto>> GetTravelClassDto(int id)
        {

            // var travelClassDto = await _context.TravelClassDto.FindAsync(id);
            var travelClassDto = await _travelClassServices.GetByIdAsync(id);


            if (travelClassDto == null)
            {
                return NotFound();
            }

            return travelClassDto;
        }

        // PUT: api/TravelClassDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelClassDto(int id, TravelClassDto travelClassDto)
        {
            await _travelClassServices.Update(travelClassDto);

            return NoContent();
        }

        // POST: api/TravelClassDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelClassDto>> PostTravelClassDto(TravelClassDto travelClassDto)
        {
          await _travelClassServices.CreateAsync(travelClassDto);

            return CreatedAtAction("GetTravelClassDto", new { id = travelClassDto.Id }, travelClassDto);
        }

        // DELETE: api/TravelClassDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelClassDto(int id)
        {
             await _travelClassServices.DeleteAsync(id);

            return NoContent();
        }

         
    }
}
