using SumeraTravelCorporation.Data.RepositoryPattern;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.TrancationServices
{

    public interface IFlightScheduleServices    
    {
        public Task<List<FlightScheduleDto>> GetAllAsync();   
             
        public Task<FlightScheduleDto?> GetByIdAsync(int id);
        public Task CreateAsync(FlightScheduleDto flightScheduleDto);
        public Task UpdateAsync(FlightScheduleDto flightScheduleDto);
        public Task DeleteAsync(int id);
        
    }

    public class FlightScheduleServices : IFlightScheduleServices
    {
        private readonly IFlightScheduleRepository _flightScheduleRepository;

        public FlightScheduleServices(IFlightScheduleRepository flightScheduleRepository)
        {
            _flightScheduleRepository = flightScheduleRepository;
        }

        public Task CreateAsync(FlightScheduleDto flightScheduleDto)
        {
            return _flightScheduleRepository.CreateAsync(flightScheduleDto);
        }

        public Task DeleteAsync(int id)
        {
            return _flightScheduleRepository.DeleteAsync(id);
        }

        public async Task<List<FlightScheduleDto>> GetAllAsync()
        {
            var flight = await _flightScheduleRepository.GetAllAsync();
            return flight.ToList();

        }

        public async Task<FlightScheduleDto?> GetByIdAsync(int id)
        {
             return await _flightScheduleRepository.GetByIdAsync(id);
        }


        public   Task UpdateAsync(FlightScheduleDto flightScheduleDto)
        {
              return _flightScheduleRepository.Update(flightScheduleDto);
        }
    }
}
