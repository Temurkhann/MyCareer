using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Interfaces.Users;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHobbyController : ControllerBase
    {
        private readonly IUserHobbyService userHobbyService;

        public UserHobbyController(IUserHobbyService userHobbyService)
        {
            this.userHobbyService = userHobbyService;
        }

        /// <summary>
        /// Create new userHobby
        /// </summary>
        /// <param name="userHobbyForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserHobbyForCreationDTO userHobbyForCreationDTO)
            => Ok(await userHobbyService.CreateAsync(userHobbyForCreationDTO));

        /// <summary>
        /// Update userHobby
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userHobbyForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserHobbyForCreationDTO
            userHobbyForCreationDTO)
            => Ok(await userHobbyService.UpdateAsync(id, userHobbyForCreationDTO));

        /// <summary>
        /// GetAll userHobby
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(await userHobbyService.GetAll(@params));

        /// <summary>
        /// Get userHobby
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await userHobbyService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete userHobby
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Deleteasync([FromRoute] int id)
            => Ok(await userHobbyService.DeleteAsync(id));
    }
}
