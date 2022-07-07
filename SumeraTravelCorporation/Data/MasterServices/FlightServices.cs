using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{

    public interface IFlightServices
    {
        Task<IEnumerable<FlightDto>> GetAllAsync();    
        Task<FlightDto> GetByIdAsync(int id);
        Task CreateAsync(FlightDto flightDto);
        Task Update(FlightDto flightDto);
        Task DeleteAsync(int id);

    }

    public class FlightServices : IFlightServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FlightServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(FlightDto flightDto)
        {
            var flight = _mapper.Map<Flight>(flightDto);
            _context.Flight.Add(flight);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(int id)
        {
            var flightToDelete = await _context.Flight.SingleAsync(d => d.Id == id);
            _context.Flight.Remove(flightToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlightDto>> GetAllAsync()
        {
            var flight = _mapper.ProjectTo<FlightDto>(_context.Flight).ToListAsync();
            return await flight;

            //var flight = await _context.Flight.ToListAsync();
            //var flightDto = flight
            //    .Select(d=> _mapper.Map<FlightDto>(d))
            //    .ToList();
            //return flightDto;
            
        }

        public async Task<FlightDto> GetByIdAsync(int id)
        {
            var flight = await _context.Flight.FirstOrDefaultAsync(d => d.Id == id);
            var flightDto = _mapper.Map<FlightDto>(flight);
            return flightDto;
        }

        public async Task Update(FlightDto flightDto)
        {
            var flightToUpdate = _mapper.Map<Flight>(flightDto);
            _context.Flight.Update(flightToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}





