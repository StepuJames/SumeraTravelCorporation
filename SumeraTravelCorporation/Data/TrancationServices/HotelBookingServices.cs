using SumeraTravelCorporation.Data.RepositoryPattern;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.TrancationServices
{
    public interface IHotelBookingServices
    {
        public Task<List<HotelBookingDto>> GetAllAsync();

        public Task<HotelBookingDto?> GetByIdAsync(int id);
        public Task CreateAsync(HotelBookingDto hotelBookingDto);
        public Task UpdateAsync(HotelBookingDto hotelBookingDto);
        public Task DeleteAsync(int id);

    }

    public class HotelBookingServices : IHotelBookingServices
    {
        private readonly IHotelBookingRepository _hotelBookingRepository;

        public HotelBookingServices(IHotelBookingRepository hotelBookingRepository )
        {
            _hotelBookingRepository = hotelBookingRepository;
        }

        public Task CreateAsync(HotelBookingDto hotelBookingDto)
        {
            return _hotelBookingRepository.CreateAsync(hotelBookingDto);
        }

        public Task DeleteAsync(int id)
        {
             return _hotelBookingRepository.DeleteAsync(id);
        }

        public async Task<List<HotelBookingDto>> GetAllAsync()
        {
             var hotel = await _hotelBookingRepository.GetAllAsync();
            return hotel.ToList();
        }

        public async Task<HotelBookingDto?> GetByIdAsync(int id)
        {
            return await _hotelBookingRepository.GetByIdAsync(id);  
        }

        public Task UpdateAsync(HotelBookingDto hotelBookingDto)
        {
            return _hotelBookingRepository.Update(hotelBookingDto);
        }
    }
}
    