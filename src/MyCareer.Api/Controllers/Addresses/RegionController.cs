using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.DTOs.Regions;
using MyCareer.Service.Interfaces.Addresses;
using MyCareer.Service.Services.Addresses;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Addresses
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService regionService;

        public RegionController(IRegionService regionService)
        {
            this.regionService = regionService;
        }

        /// <summary>
        /// Create new region
        /// </summary>
        /// <param name="regionForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(RegionForCreationDTO regionForCreationDTO)
           => Ok(await regionService.CreateAsync(regionForCreationDTO));

        /// <summary>
        /// Update region
        /// </summary>
        /// <param name="id"></param>
        /// <param name="regionForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, RegionForCreationDTO regionForCreationDTO)
            => Ok(await regionService.UpdateAsync(id, regionForCreationDTO));

        /// <summary>
        /// GetAll regions
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await regionService.GetAll(@params));

        /// <summary>
        /// Get region
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await regionService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete region
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await regionService.DeleteAsync(id));
    }
}
