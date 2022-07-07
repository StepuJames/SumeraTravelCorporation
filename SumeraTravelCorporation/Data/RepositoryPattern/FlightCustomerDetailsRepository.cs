using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.TranctionModels;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.RepositoryPattern
{

    public interface IFlightCustomerDetailsRepository
    {
        Task<IEnumerable<FlightCustomerDetailsDto>> GetAllAsync();
        Task<FlightCustomerDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(FlightCustomerDetailsDto flightCustomerDetailsDto);
        Task Update(FlightCustomerDetailsDto flightCustomerDetailsDto);
        Task DeleteAsync(int id);

    }

    public class FlightCustomerDetailsRepository : IFlightCustomerDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FlightCustomerDetailsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(FlightCustomerDetailsDto flightCustomerDetailsDto)
        {
            var flightCustomerDetails = _mapper.Map<FlightCustomerDetail>(flightCustomerDetailsDto);
            _context.FlightCustomerDetail.Add(flightCustomerDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flightCustomerDetailsToDelete = await _context.FlightCustomerDetail.SingleAsync(d => d.Id == id);
            _context.FlightCustomerDetail.Remove(flightCustomerDetailsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlightCustomerDetailsDto>> GetAllAsync()
        {
            var flightCustomerDetails = await _context.FlightCustomerDetail .ToListAsync();
            var flightCustomerDetailsDto = flightCustomerDetails
                .Select(d => _mapper.Map<FlightCustomerDetailsDto>(d))
                .ToList();
            return flightCustomerDetailsDto;
        }

        public async Task<FlightCustomerDetailsDto> GetByIdAsync(int id)
        {
            var flightCustomerDetails = await _context.FlightCustomerDetail.FirstOrDefaultAsync(d => d.Id == id);
            var flightCustomerDetailsDto = _mapper.Map<FlightCustomerDetailsDto>(flightCustomerDetails);
            return flightCustomerDetailsDto;
        }

        public async Task Update(FlightCustomerDetailsDto flightCustomerDetailsDto)
        {
            var flightCustomerDetails = _mapper.Map<FlightCustomerDetail>(flightCustomerDetailsDto);
            _context.FlightCustomerDetail .Update(flightCustomerDetails);
            await _context.SaveChangesAsync();
        }
    }
}
