using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.DropDown;
using System.Collections;

namespace SumeraTravelCorporation.Data.Services
{  
          
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(int id);
        Task CreateAsync(CityDto cityDto);
        Task Update(CityDto cityDto);
        Task DeleteAsync(int id);

        Task<IEnumerable> CityDropdown();


    }

    public class CityServices : ICityService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CityServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _context.City.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cityToDelete = await _context.City.SingleAsync(d => d.Id == id);

            _context.City.Remove(cityToDelete);
            await _context.SaveChangesAsync();
        }   
          
        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {

           // var city = await _context.City.ToListAsync();
            var cityDto =_mapper.ProjectTo<CityDto>(_context.City).ToListAsync();


            return await cityDto;

        }


        public async Task<IEnumerable> CityDropdown()
        {
            var citydropdown = await _context.City.Select( c=> new SelectDropdown
            {
                Id = c.Id,
                Name = c.Name
            }

            ).ToListAsync();

            return new SelectList(citydropdown, nameof(SelectDropdown.Id), nameof(SelectDropdown.Name)).ToList();
        }


        public async Task<CityDto> GetByIdAsync(int id)
        {
            var city = await _context.City.FirstOrDefaultAsync(d => d.Id == id);
            var cityDto = _mapper.Map<CityDto>(city);
            return cityDto;

        }

        public async Task Update(CityDto cityDto)
        {
            var cityToUpdate = await _context.City.SingleAsync(d => d.Id == cityDto.Id);

            cityToUpdate.CountryRefId = cityDto.CountryRefId;
            cityToUpdate.Name = cityDto.Name;

            _context.City.Update(cityToUpdate);
            await _context.SaveChangesAsync();
        }




    }
    }

