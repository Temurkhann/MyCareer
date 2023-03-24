using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Interfaces.Users;

namespace MyCareer.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLanguageController : ControllerBase
    {
        private readonly IUserLanguageService userLanguageService;

        public UserLanguageController(IUserLanguageService userLanguageService)
        {
            this.userLanguageService = userLanguageService;
        }

        /// <summary>
        /// Create userLanguage
        /// </summary>
        /// <param name="userLanguageForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserLanguageForCreationDTO userLanguageForCreationDTO)
            => Ok(await userLanguageService.CreateAsync(userLanguageForCreationDTO));

        /// <summary>
        /// Update userLanguage
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userLanguageForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserLanguageForCreationDTO userLanguageForCreationDTO)
            => Ok(await userLanguageService.Update(id, userLanguageForCreationDTO));

        /// <summary>
        /// GetAll userLanguages
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await userLanguageService.GetAll(@params));

        /// <summary>
        /// Get userLanguage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await userLanguageService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete userLanguage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await userLanguageService.DeleteAsync(id));
    }
}
