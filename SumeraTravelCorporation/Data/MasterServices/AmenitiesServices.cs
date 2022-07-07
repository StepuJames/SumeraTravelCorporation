using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.DropDown;
using System.Collections;

namespace SumeraTravelCorporation.Data.Services
{

    public interface IAmenitiesService
    {
        Task<IEnumerable<AmenitiesDto>> GetAllAsync();
        Task<AmenitiesDto> GetByIdAsync(int id);
        Task CreateAsync(AmenitiesDto amenitiesDto);
        Task Update(AmenitiesDto amenitiesDto);
        Task DeleteAsync(int id);
        Task<IEnumerable> AmmenitiesDropdown();

    }

    public class AmenitiesServices : IAmenitiesService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AmenitiesServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(AmenitiesDto amenitiesDto)
        {
            var hotel = _mapper.Map<Amenities>(amenitiesDto);
            _context.Amenities.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var amenitiesToDelete = await _context.Amenities.SingleAsync(d => d.Id == id);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AmenitiesDto>> GetAllAsync()
        {
            var amenities = await _context.Amenities.ToListAsync();
            var amenitiesDto = amenities
                .Select(d=>_mapper.Map<AmenitiesDto>(d))
                .ToList();
            return amenitiesDto;
        }

        public async Task<IEnumerable> AmmenitiesDropdown()
        {
            var ammenitiesdropdown = await _context.Amenities.Select(c => new SelectDropdown
            {
                Id = c.Id,
                Name = c.Name
            }

            ).ToListAsync();

            return new SelectList(ammenitiesdropdown, nameof(SelectDropdown.Id), nameof(SelectDropdown.Name)).ToList();
        }



        public async Task<AmenitiesDto> GetByIdAsync(int id)
        {
            var amenities = await _context.Amenities.FirstOrDefaultAsync(d => d.Id == id);
            var amenitiesDto = _mapper.Map<AmenitiesDto>(amenities);
            return amenitiesDto;

        }

        public async Task Update(AmenitiesDto amenitiesDto)
        {
            var amenitiesToUpdate =  await _context.Amenities.SingleAsync(d => d.Id == amenitiesDto.Id);
            amenitiesToUpdate.Name = amenitiesDto.Name;
            amenitiesToUpdate.Description = amenitiesDto.Description;

            _context.Amenities.Update(amenitiesToUpdate);
          await  _context.SaveChangesAsync();
        }
    }
}
