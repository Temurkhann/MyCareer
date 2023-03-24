using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Languages;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.Interfaces.Languages;
using MyCareer.Service.Services.Resumes;

namespace MyCareer.Api.Controllers.Languages
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService languageService;

        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        /// <summary>
        /// Create new language
        /// </summary>
        /// <param name="languageForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(LanguageForCreationDTO languageForCreationDTO)
            => Ok(await languageService.CreateAsync(languageForCreationDTO));

        /// <summary>
        /// Update language
        /// </summary>
        /// <param name="id"></param>
        /// <param name="languageForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, LanguageForCreationDTO languageForCreationDTO)
            => Ok(await languageService.Update(id, languageForCreationDTO));

        /// <summary>
        /// GetAll languages
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await languageService.GetAll(@params));

        /// <summary>
        /// Get language
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await languageService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete language
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await languageService.DeleteAsync(id));
    }
}
