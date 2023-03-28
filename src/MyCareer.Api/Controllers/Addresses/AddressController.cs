using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.Interfaces.Addresses;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Addresses
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        /// <summary>
        /// Create new address
        /// </summary>
        /// <param name="addressForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(AddressForCreationDTO addressForCreationDTO)
            => Ok(await addressService.CreateAsync(addressForCreationDTO));

        /// <summary>
        /// Update address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, AddressForCreationDTO addressForCreationDTO)
            => Ok(await addressService.UpdateAsync(id, addressForCreationDTO));

        /// <summary>
        /// GetAll addresses
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await addressService.GetAll(@params));

        /// <summary>
        /// Get address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await addressService.GetAsync(u => u.Id == id));


        /// <summary>
        /// Delete address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await addressService.DeleteAsync(id));
    }
}
