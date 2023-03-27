using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Experiences;
using MyCareer.Service.Interfaces.Experiences;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Experiences
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }

        /// <summary>
        /// Create experience
        /// </summary>
        /// <param name="experienceForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(ExperienceForCreationDTO experienceForCreationDTO)
            => Ok(await experienceService.CreateAsync(experienceForCreationDTO));

        /// <summary>
        /// Update experience
        /// </summary>
        /// <param name="id"></param>
        /// <param name="experienceForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, ExperienceForCreationDTO experienceForCreationDTO)
            => Ok(await experienceService.UpdateAsync(id, experienceForCreationDTO));

        /// <summary>
        /// GetAll experiences
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await experienceService.GetAll(@params));

        /// <summary>
        /// Get experience
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await experienceService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete experience
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await experienceService.DeleteAsync(id));
    }
}
