using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{

    public interface IHotelAmenitiesLinkService   
    {

        Task<IEnumerable<HotelAmenitiesLinkDto>> GetAllAsync();
        Task<HotelAmenitiesLinkDto> GetByIdAsync(int id);
        Task CreateAsync(HotelAmenitiesLinkDto hotelAmenitiesLinkDto);
        Task Update(HotelAmenitiesLinkDto hotelAmenitiesLinkDto);
        Task DeleteAsync(int id);
    }
    public class HotelAmenitiesLinkServices : IHotelAmenitiesLinkService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelAmenitiesLinkServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(HotelAmenitiesLinkDto hotelAmenitiesLinkDto)
        {
             var hotelAmenitiesLink = _mapper.Map<HotelAmenitiesLink>(hotelAmenitiesLinkDto);
            _context.HotelAmenitiesLink.Add(hotelAmenitiesLink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotelAmenitiesLink = await _context.HotelAmenitiesLink.SingleAsync(d => d.Id == id);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelAmenitiesLinkDto>> GetAllAsync()
        {
            var hotelAmenitiesLinkDto = _mapper.ProjectTo<HotelAmenitiesLinkDto>(_context.HotelAmenitiesLink);
            return hotelAmenitiesLinkDto;

            // var hotelAmenitiesLink = await _context.HotelAmenitiesLink.ToListAsync();
            // var hotelAmenitiesLinkDto = hotelAmenitiesLink
            //    .Select(d => _mapper.Map<HotelAmenitiesLinkDto>(d))
            //    .ToList();
            //return hotelAmenitiesLinkDto;
        }

        public async Task<HotelAmenitiesLinkDto> GetByIdAsync(int id)
        {
             var hotelAmenitiesLink = await _context.HotelAmenitiesLink.FirstOrDefaultAsync(d => d.Id == id);
            var hotelAmenitiesLinkDto = _mapper.Map<HotelAmenitiesLinkDto>(hotelAmenitiesLink);
            return hotelAmenitiesLinkDto;
        }

        public async Task Update(HotelAmenitiesLinkDto hotelAmenitiesLinkDto)
        {
             var hotelAmenitiesLinkToUpdate = await _context.HotelAmenitiesLink.SingleAsync(d => d.Id == hotelAmenitiesLinkDto.Id);
            hotelAmenitiesLinkToUpdate.HotelRefId = hotelAmenitiesLinkDto.HotelRefId;
            hotelAmenitiesLinkToUpdate.AmenitiesRefId = hotelAmenitiesLinkDto.AmenitiesRefId;

            _context.HotelAmenitiesLink.Update(hotelAmenitiesLinkToUpdate);
            await _context.SaveChangesAsync();

        }
    }
}
