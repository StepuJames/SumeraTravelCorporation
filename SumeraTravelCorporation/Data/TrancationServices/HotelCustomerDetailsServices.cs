using SumeraTravelCorporation.Data.RepositoryPattern;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.TrancationServices
{
    public interface IHotelCustomerDetailsServices
    {
        public Task<List<HotelCustomerDetailsDto>> GetAllAsync();

        public Task<HotelCustomerDetailsDto?> GetByIdAsync(int id);
        public Task CreateAsync(HotelCustomerDetailsDto hotelCustomerDetailsDto);
        public Task UpdateAsync(HotelCustomerDetailsDto hotelCustomerDetailsDto);
        public Task DeleteAsync(int id);

    }


    public class HotelCustomerDetailsServices : IHotelCustomerDetailsServices
    {
        private readonly IHotelCustomerDetailsRepository _hotelCustomerDetailsRepository;

        public HotelCustomerDetailsServices(IHotelCustomerDetailsRepository hotelCustomerDetailsRepository)
        {
            _hotelCustomerDetailsRepository = hotelCustomerDetailsRepository;
        }

        public async Task CreateAsync(HotelCustomerDetailsDto hotelCustomerDetailsDto)
        {
             await _hotelCustomerDetailsRepository.CreateAsync(hotelCustomerDetailsDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _hotelCustomerDetailsRepository.DeleteAsync(id);
        }

        public async Task<List<HotelCustomerDetailsDto>> GetAllAsync()
        {
            var customer = await _hotelCustomerDetailsRepository.GetAllAsync();
            return customer.ToList();
        }

        public async Task<HotelCustomerDetailsDto?> GetByIdAsync(int id)
        {
             return await _hotelCustomerDetailsRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(HotelCustomerDetailsDto hotelCustomerDetailsDto)
        {
            await _hotelCustomerDetailsRepository.Update(hotelCustomerDetailsDto);
        }
    }
}
