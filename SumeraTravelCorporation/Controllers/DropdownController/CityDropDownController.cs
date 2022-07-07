using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SumeraTravelCorporation.Data;
using SumeraTravelCorporation.Data.Services;
using SumeraTravelCorporation.DropDown;

namespace SumeraTravelCorporation.Controllers.DropdownController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityDropDownController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;

        private readonly ICityService _cityService;


        public CityDropDownController(ApplicationDbContext applicationDbContext, ICityService cityService)
        {
            _applicationDbContext = applicationDbContext;
            _cityService = cityService;
        }


        [HttpGet]



        public async Task<ActionResult<IEnumerable<SelectDropdown>>> CountryDropDownList()
        {
            var cityDropDown = await _cityService.CityDropdown();
            return Ok(cityDropDown);
        }
    }
}



