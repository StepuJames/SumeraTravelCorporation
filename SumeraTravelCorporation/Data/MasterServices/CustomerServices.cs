using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{

    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task CreateAsync(CustomerDto customerDto);
        Task Update(CustomerDto customerDto);
        Task DeleteAsync(int id);

    }


    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customerToDelete = await _context.Customer.SingleAsync(d => d.Id == id);
            _context.Customer.Remove(customerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customer = await _context.Customer.ToListAsync();
            var customerDto = customer
                .Select(d => _mapper.Map<CustomerDto>(d))
                .ToList();
            return customerDto;


        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(d => d.Id == id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        public async Task Update(CustomerDto customerDto)
        {
            var customerToUpdate = _mapper.Map<Customer>(customerDto);
            _context.Customer.Update(customerToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}





