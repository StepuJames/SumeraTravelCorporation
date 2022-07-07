using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sumera.Data.Models.MasterModels;
using SumeraTravelCorporation.Data.Dtos;

namespace SumeraTravelCorporation.Data.Services
{
    public interface IHotelRoomServices
    {
        Task<IEnumerable<HotelRoomDto>> GetAllAsync();
        Task<HotelRoomDto> GetByIdAsync(int id);
        Task CreateAsync(HotelRoomDto hotelRoomDto);
        Task Update(HotelRoomDto hotelRoomDto);
        Task DeleteAsync(int id);

    }

    public class HotelRoomServices : IHotelRoomServices



    {


        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelRoomServices(ApplicationDbContext applicationDbContext, IMapper mapper  )
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(HotelRoomDto hotelRoomDto)
        {   
            var hotelRoom = _mapper.Map<HotelRooms>(hotelRoomDto);
            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        { 
            var hotelRoom = await _context.HotelRoom.SingleAsync(d => d.Id == id);
            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<HotelRoomDto>> GetAllAsync()
        {
            var hotelRoom = await _context.HotelRoom.ToListAsync();
            var hotelRoomDto = hotelRoom
                .Select(d => _mapper.Map<HotelRoomDto>(d))
                .ToList();
            return hotelRoomDto;
        }

        public async Task<HotelRoomDto> GetByIdAsync(int id)
        {
            var hotelRoom = await _context.HotelRoom.FirstOrDefaultAsync(d => d.Id == id);
            var hotelRoomDto = _mapper.Map<HotelRoomDto>(hotelRoom);
            return hotelRoomDto;
        }

        public async Task Update(HotelRoomDto hotelRoomDto)
        {
            var hotelRoomToUpdate = _mapper.Map<HotelRooms>(hotelRoomDto);
            _context.HotelRoom.Update(hotelRoomToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
