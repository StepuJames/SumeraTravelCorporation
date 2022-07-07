using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{

    public interface IFlightAmenitiesLinkServices
    {
        Task<IEnumerable<FlightAmenitiesLinkDto>> GetAllAsync();
        Task<FlightAmenitiesLinkDto> GetByIdAsync(int id);
        Task CreateAsync(FlightAmenitiesLinkDto flightAmenitiesLinkDto);
        Task Update(FlightAmenitiesLinkDto flightAmenitiesLinkDto);
        Task DeleteAsync(int id);

    }
    public class FlightAmenitiesLinkServices : IFlightAmenitiesLinkServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FlightAmenitiesLinkServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(FlightAmenitiesLinkDto flightAmenitiesLinkDto)
        {
            var flightAmenitiesLink = _mapper.Map<FlightAmenitiesLink>(flightAmenitiesLinkDto);
            _context.FlightAmenitiesLink.Add(flightAmenitiesLink);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var flightAmenitiesLinkToDelete = await _context.FlightAmenitiesLink.SingleAsync(d => d.Id == id);
            _context.FlightAmenitiesLink.Remove(flightAmenitiesLinkToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlightAmenitiesLinkDto>> GetAllAsync()
        {
            var flightAmenitiesLink = await _context.FlightAmenitiesLink.ToListAsync();
            var flightAmenitiesLinkDto = flightAmenitiesLink
                .Select(d => _mapper.Map<FlightAmenitiesLinkDto>(d))
                .ToList();
            return flightAmenitiesLinkDto;
        }

        public async Task<FlightAmenitiesLinkDto> GetByIdAsync(int id)
        {
            var flightAmenitiesLink = await _context.FlightAmenitiesLink.FirstOrDefaultAsync(d => d.Id == id);
            var flightAmenitiesLinkDto = _mapper.Map<FlightAmenitiesLinkDto>(flightAmenitiesLink);
            return flightAmenitiesLinkDto;
        }

        public async Task Update(FlightAmenitiesLinkDto flightAmenitiesLinkDto)
        {
            var flightAmenitiesLinkToUpdate = _mapper.Map<FlightAmenitiesLink>(flightAmenitiesLinkDto);
            _context.FlightAmenitiesLink.Update(flightAmenitiesLinkToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
