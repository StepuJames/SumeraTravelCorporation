using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Services
{

    public interface IAirlineServices
    {
        Task<IEnumerable<AirlineDto>> GetAllAsync();
        Task<AirlineDto> GetByIdAsync(int id);
        Task CreateAsync(AirlineDto airlineDto);
        Task Update(AirlineDto airlineDto);
        Task DeleteAsync(int id);

    }
    public class AirlineServices : IAirlineServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AirlineServices(ApplicationDbContext context, IMapper mapper,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task CreateAsync(AirlineDto airlineDto)
        {

            string wwwRootPath = _hostEnvironment.ContentRootPath;
            string filename = Path.GetFileNameWithoutExtension(airlineDto.Images.FileName);
            string extensions = Path.GetExtension(airlineDto.Images.FileName);

            airlineDto.Logo = filename+DateTime.Now.ToString("yymmssfff") + extensions;
            string path = Path.Combine(wwwRootPath + "/UploadedFiles" , filename);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await airlineDto.Images.CopyToAsync(stream);
            }




                var airline = _mapper.Map<Airline>(airlineDto);
            _context.Airline.Add(airline);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var airlineToDelete = await _context.Airline.SingleAsync(d => d.Id == id);
            _context.Airline.Remove(airlineToDelete);   
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<AirlineDto>> GetAllAsync()
        {
           var airline = await _context.Airline.ToListAsync();
            var airlineDto = airline
                .Select(d => _mapper.Map<AirlineDto>(d))
                .ToList();
            return airlineDto;
        }

        public async Task<AirlineDto> GetByIdAsync(int id)
        {
          var airline = await _context.Airline.FirstOrDefaultAsync(d => d.Id == id);
            var airlineDto = _mapper.Map<AirlineDto>(airline);
            return airlineDto;
        }

        public async Task Update(AirlineDto airlineDto)
        {
            var airlineToUpdate = _mapper.Map<Airline>(airlineDto);
            _context.Airline.Update(airlineToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
