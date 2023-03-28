using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.DTOs.Countries;
using MyCareer.Service.Interfaces.Addresses;
using MyCareer.Service.Services.Addresses;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Addresses
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        /// <summary>
        /// Create new country
        /// </summary>
        /// <param name="countryForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CountryForCreationDTO countryForCreationDTO)
           => Ok(await countryService.CreateAsync(countryForCreationDTO));

        /// <summary>
        /// Update country
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, CountryForCreationDTO countryForCreationDTO)
            => Ok(await countryService.UpdateAsync(id, countryForCreationDTO));

        /// <summary>
        /// GetAll countries
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await countryService.GetAll(@params));

        /// <summary>
        /// Get country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await countryService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await countryService.DeleteAsync(id));
    }
}
