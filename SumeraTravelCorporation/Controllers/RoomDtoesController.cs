using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Dtos;
using SumeraTravelCorporation.Data.Services;

namespace SumeraTravelCorporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDtoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRoomServices _roomService;

        public RoomDtoesController(ApplicationDbContext context, IMapper mapper, IRoomServices roomServices)
        {
            _context = context;
            _mapper = mapper;
            _roomService = roomServices;
        }

        // GET: api/RoomDtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomDto()
        {

            //return await _context.RoomDto.ToListAsync();
            var roomDto = await _roomService.GetAllAsync();
            return Ok(roomDto);
        }

        // GET: api/RoomDtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoomDto(int id)
        {

            // var roomDto = await _context.RoomDto.FindAsync(id);
            var roomDto = await _roomService.GetByIdAsync(id);


            if (roomDto == null)
            {
                return NotFound();
            }

            return roomDto;
        }

        // PUT: api/RoomDtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomDto(int id, RoomDto roomDto)
        {
             await _roomService.Update(roomDto);

            return NoContent();
        }

        // POST: api/RoomDtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomDto>> PostRoomDto(RoomDto roomDto)
        {
          
             await _roomService.CreateAsync(roomDto);


            return CreatedAtAction("GetRoomDto", new { id = roomDto.Id }, roomDto);
        }

        // DELETE: api/RoomDtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomDto(int id)
        {
             await _roomService.DeleteAsync(id);

            return NoContent();
        }

         
    }
}
