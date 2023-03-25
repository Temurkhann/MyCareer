using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Interfaces.Users;

namespace MyCareer.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserForCreationDTO userForCreationDTO)
            => Ok(await userService.CreateAsync(userForCreationDTO));

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userForUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserForUpdateDTO userForUpdateDTO)
            => Ok(await userService.UpdateAsync(id, userForUpdateDTO));

        /// <summary>
        /// GetAll all users
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await userService.GetAllAsync(@params));

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await userService.GetAsync(u => u.Id == id));

        /// <summary>
        /// User Change Password
        /// </summary>
        /// <param name="userForChangePasswordDTO"></param>
        /// <returns></returns>
        [HttpPatch("password")]
        public async ValueTask<IActionResult> ChangePasswordAsync(UserForChangePasswordDTO userForChangePasswordDTO)
            => Ok(await userService.ChangePasswordAsync(userForChangePasswordDTO));


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await userService.DeleteAsync(id));
    }
}
