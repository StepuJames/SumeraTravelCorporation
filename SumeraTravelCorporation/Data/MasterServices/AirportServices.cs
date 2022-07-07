using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{
    public interface IAirportServices
    {   
        Task<IEnumerable<AirportDto>> GetAllAsync();  
        Task<AirportDto> GetByIdAsync(int id);
        Task CreateAsync(AirportDto airportDto);
        Task Update(AirportDto airportDto);
        Task DeleteAsync(int id);

    }

    public class AirportServices : IAirportServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AirportServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task CreateAsync(AirportDto airportDto)
        {
             var airport = _mapper.Map<Airport>(airportDto);
            _context.Airport.Add(airport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var airportToDelete = await _context.Airport.SingleAsync(d => d.Id == id);
            _context.Airport.Remove(airportToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AirportDto>> GetAllAsync()
        {
            var airport = _mapper.ProjectTo<AirportDto>(_context.Airport).ToListAsync();
            return await airport;

            //var airport = await _context.Airport.ToListAsync();
            //var airtportDto = airport
            //    .Select(d=> _mapper.Map<AirportDto>(d))
            //    .ToList();
            //return airtportDto;
        }

        public async Task<AirportDto> GetByIdAsync(int id)
        {
            var airport = await _context.Country.FirstOrDefaultAsync(d=>d.Id == id);
            var airportDto = _mapper.Map<AirportDto>(airport);
            return airportDto;
        }

        public async Task Update(AirportDto airportDto)
        {
            var airtportToUpdate =  _mapper.Map<Airport>(airportDto);
            _context.Airport.Update(airtportToUpdate);
            await _context.SaveChangesAsync();

        }
    }
}
