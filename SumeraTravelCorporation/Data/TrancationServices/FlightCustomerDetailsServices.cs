using SumeraTravelCorporation.Data.RepositoryPattern;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.TrancationServices
{

    public interface IFlightCustomerDetailsServices
    {
        public Task<List<FlightCustomerDetailsDto>> GetAllAsync();

        public Task<FlightCustomerDetailsDto?> GetByIdAsync(int id);
        public Task CreateAsync(FlightCustomerDetailsDto flightCustomerDetailsDto);
        public Task UpdateAsync(FlightCustomerDetailsDto flightCustomerDetailsDto);
        public Task DeleteAsync(int id);

    }
    public class FlightCustomerDetailsServices : IFlightCustomerDetailsServices
    {
        private readonly IFlightCustomerDetailsRepository _flightCustomerDetailsRepository;

        public FlightCustomerDetailsServices(IFlightCustomerDetailsRepository flightCustomerDetailsRepository)
        {
             _flightCustomerDetailsRepository = flightCustomerDetailsRepository;
        }

        public async Task CreateAsync(FlightCustomerDetailsDto flightCustomerDetailsDto)
        {
            await _flightCustomerDetailsRepository.CreateAsync(flightCustomerDetailsDto);
        }

        public async Task DeleteAsync(int id)
        {
             await  _flightCustomerDetailsRepository.DeleteAsync(id);
        }

        public async Task<List<FlightCustomerDetailsDto>> GetAllAsync()
        {

           var customer =   await  _flightCustomerDetailsRepository.GetAllAsync();
            return customer.ToList();
        }

        public async Task<FlightCustomerDetailsDto?> GetByIdAsync(int id)
        {
          return await _flightCustomerDetailsRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(FlightCustomerDetailsDto flightCustomerDetailsDto)
        {
            await _flightCustomerDetailsRepository.Update(flightCustomerDetailsDto);
        }
    }
}
