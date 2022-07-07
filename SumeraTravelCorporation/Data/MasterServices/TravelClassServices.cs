using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.MasterModels;

namespace SumeraTravelCorporation.Data.Services
{

    public interface ITravelClassServices
    {
        Task<IEnumerable<TravelClassDto>> GetAllAsync();
        Task<TravelClassDto> GetByIdAsync(int id);
        Task CreateAsync(TravelClassDto travelClassDto);
        Task Update(TravelClassDto travelClassDto);
        Task DeleteAsync(int id);

    }
    public class TravelClassServices : ITravelClassServices
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TravelClassServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(TravelClassDto travelClassDto)
        {
            var travelClass = _mapper.Map<TravelClass>(travelClassDto);
            _context.TravelClass.Add(travelClass);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var travelClassToDelete = await _context.TravelClass.SingleAsync(d => d.Id == id);
            _context.TravelClass.Remove(travelClassToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TravelClassDto>> GetAllAsync()
        {
            var travelClass = await _context.TravelClass.ToListAsync();
            var travelClassDto = travelClass
                .Select(d => _mapper.Map<TravelClassDto>(d))
                .ToList();
            return travelClassDto;
        }

        public async Task<TravelClassDto> GetByIdAsync(int id)
        {
            var travelClass = await _context.TravelClass.FirstOrDefaultAsync(d => d.Id == id);
            var travelClassDto = _mapper.Map<TravelClassDto>(travelClass);
            return travelClassDto;
        }

        public async Task Update(TravelClassDto travelClassDto)
        {
            var travelClassToUpdate = _mapper.Map<TravelClass>(travelClassDto);
            _context.TravelClass.Update(travelClassToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
