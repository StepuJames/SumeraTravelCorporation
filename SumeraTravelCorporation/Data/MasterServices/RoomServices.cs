using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sumera.Data.Models.MasterModels;
using SumeraTravelCorporation.Data.Dtos;

namespace SumeraTravelCorporation.Data.Services
{

    public interface IRoomServices
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(int id);
        Task CreateAsync(RoomDto roomDto);
        Task Update(RoomDto roomDto);
        Task DeleteAsync(int id);

    }

    public class RoomServices : IRoomServices
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoomServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roomToDelete = await _context.Room.SingleAsync(d => d.Id == id);
            _context.Room.Remove(roomToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var room = await _context.Room.ToListAsync();
            var roomDto = room
                .Select(d => _mapper.Map<RoomDto>(d))
                .ToList();
            return roomDto;
        }

        public async Task<RoomDto> GetByIdAsync(int id)
        {
            var room = await _context.Room.FirstOrDefaultAsync(d => d.Id == id);
            var roomDto = _mapper.Map<RoomDto>(room);
            return roomDto;
        }

        public async Task Update(RoomDto roomDto)
        {
            var roomToUpdate = _mapper.Map<Room>(roomDto);
            _context.Room.Update(roomToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
