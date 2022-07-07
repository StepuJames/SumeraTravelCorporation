using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Services;
using SumeraTravelCorporation.DropDown;

namespace SumeraTravelCorporation.Controllers.DropdownController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AminitiesDropDownController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IAmenitiesService _amenitiesService;

        public AminitiesDropDownController(ApplicationDbContext applicationDbContext, IAmenitiesService amenitiesService)
        {
            _applicationDbContext = applicationDbContext;
            _amenitiesService = amenitiesService;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<SelectDropdown>>> CountryDropDownList()
        {
            var hotelDropDown = await _amenitiesService.AmmenitiesDropdown();
            return Ok(hotelDropDown);


        }


    }
}
