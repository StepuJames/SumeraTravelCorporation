using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.DropDown;
using System.Collections;

namespace SumeraTravelCorporation.Data.Services
{
        
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllAsync();
        Task<HotelDto> GetByIdAsync(int id);
        Task CreateAsync(HotelDto hotelDto);
        Task Update(HotelDto hotelDto);
        Task DeleteAsync(int id);
        Task<IEnumerable> HotelDropdown();
    }

    public class HotelServices: IHotelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
 
        public async Task CreateAsync(HotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotelToDelete = await _context.Hotel.SingleAsync(d => d.Id == id);

            _context.Hotel.Remove(hotelToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelDto>> GetAllAsync()
        {
            var hotelDto = _mapper.ProjectTo<HotelDto>(_context.Hotel);

            return hotelDto;


           // var hotel = await _context.Hotel.ToListAsync();
           // var hotelDto = hotel
           //.Select(d => _mapper.Map<HotelDto>(d))
           //.ToList();
           // return hotelDto;
        }

        public async Task<IEnumerable> HotelDropdown()
        {
            var hoteldropdown = await _context.Hotel.Select(c => new SelectDropdown
            {
                Id = c.Id,
                Name = c.Name
            }

            ).ToListAsync();

            return new SelectList(hoteldropdown, nameof(SelectDropdown.Id), nameof(SelectDropdown.Name)).ToList();
        }


        public async Task<HotelDto> GetByIdAsync(int id)
        {
            var hotel = await _context.Hotel.FirstOrDefaultAsync(d => d.Id == id);
            var hotelDto = _mapper.Map<HotelDto>(hotel);
            return hotelDto;
        }

        public async Task Update(HotelDto hotelDto)
        {
            var hotelToUpdate = await _context.Hotel.SingleAsync(d => d.Id == hotelDto.Id);

            hotelToUpdate.Star = hotelDto.Star;
            hotelToUpdate.Name = hotelDto.Name;
            hotelToUpdate.CityRefId = hotelDto.CityRefId;
            

            _context.Hotel.Update(hotelToUpdate);
            await _context.SaveChangesAsync();
        }

    }
}
