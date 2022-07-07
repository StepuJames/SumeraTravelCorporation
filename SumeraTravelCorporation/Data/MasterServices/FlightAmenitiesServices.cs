using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{

    public interface IFlightAmenitiesServices
    {
        Task<IEnumerable<FlightAmenitiesDto>> GetAllAsync();
        Task<FlightAmenitiesDto> GetByIdAsync(int id);
        Task CreateAsync(FlightAmenitiesDto flightAmenitiesDto);
        Task Update(FlightAmenitiesDto flightAmenitiesDto);
        Task DeleteAsync(int id);

    }
    public class FlightAmenitiesServices : IFlightAmenitiesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public FlightAmenitiesServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task CreateAsync(FlightAmenitiesDto flightAmenitiesDto)
        {
            var flightAmenities = _mapper.Map<FlightAmenities>(flightAmenitiesDto);
            _context.FlightAmenities.Add(flightAmenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flightAmenitiesToDelete = await _context.FlightAmenities.SingleAsync(d => d.Id == id);
            _context.FlightAmenities.Remove(flightAmenitiesToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlightAmenitiesDto>> GetAllAsync()
        {
            var flightAmenities = await _context.FlightAmenities.ToListAsync();
            var flightAmenitiesDto = flightAmenities
                .Select(d => _mapper.Map<FlightAmenitiesDto>(d))
                .ToList();
            return flightAmenitiesDto;
        }

        public async Task<FlightAmenitiesDto> GetByIdAsync(int id)
        {
            var flightAmenities = await _context.FlightAmenities.FirstOrDefaultAsync(d => d.Id == id);
            var flightAmenitiesDto = _mapper.Map<FlightAmenitiesDto>(flightAmenities);
            return flightAmenitiesDto;
        }

        public async Task Update(FlightAmenitiesDto flightAmenitiesDto)
        {
            var flightAmenitiesToUpdate = _mapper.Map<FlightAmenities>(flightAmenitiesDto);
            _context.FlightAmenities.Update(flightAmenitiesToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
