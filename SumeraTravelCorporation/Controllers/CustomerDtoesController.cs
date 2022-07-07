using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Services;


namespace SumeraTravelCorporation.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICustomerServices _customerService;

        public CustomerDtoesController(ApplicationDbContext context, IMapper mapper, ICustomerServices customerServices)
        {
            _context = context;
            _mapper = mapper;
            _customerService = customerServices;

        }

        // GET: api/CustomerDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomerDto()
        {
          
           // return await _context.CustomerDto.ToListAsync();
           var customerDto = await _customerService.GetAllAsync();
            return Ok(customerDto);
        }

        // GET: api/CustomerDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerDto(int id)
        {

            //var customerDto = await _context.CustomerDto.FindAsync(id);
            var customerDto = await _customerService.GetByIdAsync(id);


            if (customerDto == null)
            {
                return NotFound();
            }

            return customerDto;
        }

        // PUT: api/CustomerDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDto(int id, CustomerDto customerDto)
        {
            
            await _customerService.Update(customerDto);
            return NoContent();
        }

        // POST: api/CustomerDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomerDto(CustomerDto customerDto)
        {
          
            await _customerService.CreateAsync(customerDto);
            return CreatedAtAction("GetCustomerDto", new { id = customerDto.Id }, customerDto);
        }

        // DELETE: api/CustomerDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDto(int id)
        {
             await _customerService.DeleteAsync(id);

            return NoContent();
        }

        
    }
}
