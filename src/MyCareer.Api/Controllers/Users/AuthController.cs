using Microsoft.AspNetCore.Mvc;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Interfaces.Users;

namespace MyCareer.Api.Controllers.Users
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        /// <summary>
        /// Authorization
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO dto)
        {
            var token = await authService.GenerateToken(dto.Email, dto.Password);
            return Ok(new
            {
                token
            });
        }
    }
}
