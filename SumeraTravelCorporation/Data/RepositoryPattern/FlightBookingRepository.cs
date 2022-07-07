using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.TranctionModels;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.RepositoryPattern
{

    public interface IFlightBookingRepository    
    {
        Task<IEnumerable<FlightBookingDto>> GetAllAsync();
        Task<FlightBookingDto> GetByIdAsync(int id);
        Task CreateAsync(FlightBookingDto flightBookingDto);
        Task Update(FlightBookingDto flightBookingDto);
        Task DeleteAsync(int id);

    }

    public class FlightBookingRepository : IFlightBookingRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FlightBookingRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(FlightBookingDto flightBookingDto)
        {
            var flightBooking = _mapper.Map<FlightBooking>(flightBookingDto);
            _context.FlightBooking.Add(flightBooking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flightBookingToDelete = await _context.FlightBooking.SingleAsync(d => d.Id == id);
            _context.FlightBooking.Remove(flightBookingToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlightBookingDto>> GetAllAsync()
        {
            var flightBooking = await _context.FlightBooking.ToListAsync();
            var flightBookingDto = flightBooking
                .Select(d => _mapper.Map<FlightBookingDto>(d))
                .ToList();
            return flightBookingDto;
        }

        public async Task<FlightBookingDto> GetByIdAsync(int id)
        {
            var flightBooking = await _context.FlightBooking.FirstOrDefaultAsync(d => d.Id == id);
            var flightBookingDto = _mapper.Map<FlightBookingDto>(flightBooking);
            return flightBookingDto;
        }   

        public async Task Update(FlightBookingDto flightBookingDto)
        {
            var flightBookingToUpdate = _mapper.Map<FlightBooking>(flightBookingDto);
            _context.FlightBooking.Update(flightBookingToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
   