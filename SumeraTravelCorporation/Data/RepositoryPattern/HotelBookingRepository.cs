using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.TranctionModels;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.RepositoryPattern
{

    public interface IHotelBookingRepository
    {
        Task<IEnumerable<HotelBookingDto>> GetAllAsync();
        Task<HotelBookingDto> GetByIdAsync(int id);
        Task CreateAsync(HotelBookingDto hotelBookingDto);
        Task Update(HotelBookingDto hotelBookingDto);
        Task DeleteAsync(int id);

    }
    public class HotelBookingRepository : IHotelBookingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelBookingRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(HotelBookingDto hotelBookingDto)
        {
            var hotelBooking = _mapper.Map<HotelBooking>(hotelBookingDto);
            _context.HotelBooking.Add(hotelBooking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotelBookingToDelete = await _context.HotelBooking.SingleAsync(d => d.Id == id);
            _context.HotelBooking.Remove(hotelBookingToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelBookingDto>> GetAllAsync()
        {
            var hotelBooking = await _context.HotelBooking.ToListAsync();
            var hotelBookingDto = hotelBooking
                .Select(d => _mapper.Map<HotelBookingDto>(d))
                .ToList();
            return hotelBookingDto;
        }

        public async Task<HotelBookingDto> GetByIdAsync(int id)
        {
            var hotelBooking = await _context.HotelBooking.FirstOrDefaultAsync(d => d.Id == id);
            var hotelBookingDto = _mapper.Map<HotelBookingDto>(hotelBooking);
            return hotelBookingDto;
        }

        public async Task Update(HotelBookingDto hotelBookingDto)
        {
            var hotelBookingToUpdate = _mapper.Map<HotelBooking>(hotelBookingDto);
            _context.HotelBooking.Update(hotelBookingToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
