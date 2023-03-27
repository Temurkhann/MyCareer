using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Hobbies;
using MyCareer.Service.Interfaces.Hobbies;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Hobbies
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IHobbyService hobbyService;

        public HobbyController(IHobbyService hobbyService)
        {
            this.hobbyService = hobbyService;
        }

        /// <summary>
        /// Create new hobby
        /// </summary>
        /// <param name="hobbyForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(HobbyForCreationDTO hobbyForCreationDTO)
            => Ok(await hobbyService.CreateAsync(hobbyForCreationDTO));

        /// <summary>
        /// Update hobby
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hobbyForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, HobbyForCreationDTO hobbyForCreationDTO)
            => Ok(await hobbyService.UpdateAsync(id, hobbyForCreationDTO));

        /// <summary>
        /// Get hobby
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await hobbyService.GetAsync(u => u.Id == id));

        /// <summary>
        /// GetAll hobbies
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await hobbyService.GetAll(@params));

        /// <summary>
        /// Delete hobby
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await hobbyService.DeleteAsync(id));
    }
}
