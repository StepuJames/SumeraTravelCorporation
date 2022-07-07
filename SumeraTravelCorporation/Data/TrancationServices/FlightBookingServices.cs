using SumeraTravelCorporation.Data.RepositoryPattern;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.TrancationServices
{
    public interface IFlightBookingServices
    {
        public Task<List<FlightBookingDto>> GetAllAsync();

        public Task<FlightBookingDto?> GetByIdAsync(int id);
        public Task CreateAsync(FlightBookingDto flightBookingDto);
        public Task UpdateAsync(FlightBookingDto flightBookingDto);
        public Task DeleteAsync(int id);

    }

       


    public class FlightBookingServices : IFlightBookingServices
    {

        private readonly IFlightBookingRepository _flightBookingRepository;

        public FlightBookingServices(IFlightBookingRepository flightBookingRepository)
        {
            _flightBookingRepository = flightBookingRepository;
        }

        public Task CreateAsync(FlightBookingDto flightBookingDto)
        {
             return _flightBookingRepository.CreateAsync(flightBookingDto);
        }

        public Task DeleteAsync(int id)
        {
            return _flightBookingRepository.DeleteAsync(id);
        }

        public async Task<List<FlightBookingDto>> GetAllAsync()
        {
             var flight = await _flightBookingRepository.GetAllAsync();
            return flight.ToList();
        }

        public async Task<FlightBookingDto?> GetByIdAsync(int id)
        {
          return  await _flightBookingRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(FlightBookingDto flightBookingDto)
        {
            return _flightBookingRepository.Update(flightBookingDto);
        }
    }
}
