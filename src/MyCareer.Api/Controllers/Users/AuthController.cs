using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Interfaces.Users;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Users
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        /// <summary>
        /// Authorization
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async ValueTask<IActionResult> Login(UserForLoginDTO dto)
        {
            var token = await authService.GenerateToken(dto.Email, dto.Password);
            return Ok(new
            {
                token
            });
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="userForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async ValueTask<IActionResult> CreateAsync(UserForCreationDTO userForCreationDTO)
            => Ok(await userService.CreateAsync(userForCreationDTO));
    }
}
