using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Services;
using SumeraTravelCorporation.DropDown;

namespace SumeraTravelCorporation.Controllers.DropdownController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDropDownController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IHotelService _hotelService;


        public HotelDropDownController(ApplicationDbContext applicationDbContext, IHotelService hotelService)
        {
            _applicationDbContext = applicationDbContext;
            _hotelService = hotelService;
        }

        [HttpGet]



        public async Task<ActionResult<IEnumerable<SelectDropdown>>> CountryDropDownList()
        {
            var hotelDropDown = await _hotelService.HotelDropdown(); 
            return Ok(hotelDropDown);


        }
    }
}
