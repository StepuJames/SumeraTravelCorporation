using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{

    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<CountryDto> GetByIdAsync(int id);
        Task CreateAsync(CountryDto countryDto);
        Task Update(CountryDto countryDto);
        Task DeleteAsync(int id);
    }
    public class CountryServices: ICountryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CountryServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryDto countryDto )
        {
            var country = _mapper.Map<Country>(countryDto);
            _context.Country.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {       
            var countryToDelete = await _context.Country.SingleAsync(d => d.Id == id);

            _context.Country.Remove(countryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var country = await _context.Country.ToListAsync();
            var countryDto = country
           .Select(d => _mapper.Map<CountryDto>(d))
           .ToList();
            return countryDto;
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            var country = await _context.Country.FirstOrDefaultAsync(d => d.Id == id);
            var countryDto = _mapper.Map<CountryDto>(country);
            return countryDto;
        }


        public async Task Update(CountryDto cityDto)
        {
            var countryToUpdate = await _context.Country.SingleAsync(d => d.Id == cityDto.Id);

            countryToUpdate.Code = cityDto.Code;
            countryToUpdate.Name = cityDto.Name;

            _context.Country.Update(countryToUpdate);
            await _context.SaveChangesAsync();
        }


    }
}
