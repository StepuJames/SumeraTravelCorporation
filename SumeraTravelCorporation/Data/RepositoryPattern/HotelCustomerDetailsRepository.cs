using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.TranctionModels;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.RepositoryPattern
{

    public interface IHotelCustomerDetailsRepository
    {
        Task<IEnumerable<HotelCustomerDetailsDto>> GetAllAsync();
        Task<HotelCustomerDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(HotelCustomerDetailsDto hotelCustomerDetailsDto);
        Task Update(HotelCustomerDetailsDto hotelCustomerDetailsDto);
        Task DeleteAsync(int id);

    }

    public class HotelCustomerDetailsRepository : IHotelCustomerDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelCustomerDetailsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(HotelCustomerDetailsDto hotelCustomerDetailsDto)
        {
            var hotelCustomerDetails = _mapper.Map<HotelCustomerDetails>(hotelCustomerDetailsDto);
            _context.HotelCustomerDetails.Add(hotelCustomerDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotelCustomerDetailsToDelete = await _context.HotelCustomerDetails.SingleAsync(d => d.Id == id);
            _context.HotelCustomerDetails.Remove(hotelCustomerDetailsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelCustomerDetailsDto>> GetAllAsync()
        {
            var hotelCustomerDetails = await _context.HotelCustomerDetails.ToListAsync();
            var hotelCustomerDetailsDto = hotelCustomerDetails
                .Select(d => _mapper.Map<HotelCustomerDetailsDto>(d))
                .ToList();
            return hotelCustomerDetailsDto;
        }

        public async Task<HotelCustomerDetailsDto> GetByIdAsync(int id)
        {
            var hotelCustomerDetails = await _context.HotelCustomerDetails.FirstOrDefaultAsync(d => d.Id == id);
            var hotelCustomerDetailsDto = _mapper.Map<HotelCustomerDetailsDto>(hotelCustomerDetails);
            return hotelCustomerDetailsDto;
        }

        public async Task Update(HotelCustomerDetailsDto hotelCustomerDetailsDto)
        {
            var hotelCustomerDetails = _mapper.Map<HotelCustomerDetails>(hotelCustomerDetailsDto);
            _context.HotelCustomerDetails.Update(hotelCustomerDetails);
            await _context.SaveChangesAsync();
        }
    }
}
