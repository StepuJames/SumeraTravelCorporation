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
    public class CountryDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;

        public CountryDtoesController(ApplicationDbContext context,IMapper mapper, ICountryService countryService)
        {
            _context = context;
            _mapper = mapper;
            _countryService = countryService;
        }

        // GET: api/CountryDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountryDto()
        {
          
            //return await _context.CountryDto.ToListAsync();
            var countryDto = await _countryService.GetAllAsync();
            return Ok(countryDto);
        }

        // GET: api/CountryDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountryDto(int id)
        {
         
            //var countryDto = await _context.CountryDto.FindAsync(id);
            var countryDto = await  _countryService.GetByIdAsync(id);
            if (countryDto == null)
            {
                return NotFound();
            }

            return countryDto;
        }

        // PUT: api/CountryDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryDto(int id, CountryDto countryDto)
        {
            
            await _countryService.Update(countryDto);
            

            return NoContent();
        }

        // POST: api/CountryDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryDto>> PostCountryDto(CountryDto countryDto)
        {
           
         await _countryService.CreateAsync(countryDto);
            return CreatedAtAction("GetCountryDto",new { id = countryDto.Id },countryDto);
            
        }

        // DELETE: api/CountryDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryDto(int id)
        {
            
          await _countryService.DeleteAsync(id);

            return NoContent();
        }

        
    }
}
