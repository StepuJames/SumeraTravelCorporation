using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.TranctionModels;
using SumeraTravelCorporation.Data.TranctionsDto;

namespace SumeraTravelCorporation.Data.RepositoryPattern
{

    public interface IFlightScheduleRepository
    {    
        Task<IEnumerable<FlightScheduleDto>> GetAllAsync();
        Task<FlightScheduleDto> GetByIdAsync(int id);
        Task CreateAsync(FlightScheduleDto flightScheduleDto);
        Task Update(FlightScheduleDto flightScheduleDto);
        Task DeleteAsync(int id);

    }     

    public class FlightScheduleRepository : IFlightScheduleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FlightScheduleRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(FlightScheduleDto flightScheduleDto)
        {
            var flightSchedule = _mapper.Map<FlightSchedule>(flightScheduleDto);
            _context.FlightSchedule.Add(flightSchedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flightScheduleToDelete = await _context.FlightSchedule.SingleAsync(d => d.Id == id);
            _context.FlightSchedule.Remove(flightScheduleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlightScheduleDto>> GetAllAsync()
        {
            var flightSchedule = await _context.FlightSchedule.ToListAsync();
            var flightScheduleDto = flightSchedule
                .Select(d => _mapper.Map<FlightScheduleDto>(d))
                .ToList();
            return flightScheduleDto;
        }


        public async Task<FlightScheduleDto> GetByIdAsync(int id)
        {
            var flightSchedule = await _context.FlightSchedule.FirstOrDefaultAsync(d => d.Id == id);
            var flightScheduleDto = _mapper.Map<FlightScheduleDto>(flightSchedule);
            return flightScheduleDto;
        }

        public async Task Update(FlightScheduleDto flightScheduleDto)
        {
            var flightScheduleToUpdate = _mapper.Map<FlightSchedule>(flightScheduleDto);
            _context.FlightSchedule.Update(flightScheduleToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}


