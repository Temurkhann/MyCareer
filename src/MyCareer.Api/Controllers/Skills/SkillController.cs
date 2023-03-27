using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.DTOs.Talents;
using MyCareer.Service.Interfaces.Skills;
using MyCareer.Service.Interfaces.Talents;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Skills
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;

        private readonly ITalentService talentService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        /// <summary>
        /// Create new skill
        /// </summary>
        /// <param name="skillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(SkillForCreationDTO skillForCreationDTO)
            => Ok(await skillService.CreateAsync(skillForCreationDTO));

        /// <summary>
        /// Update skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, SkillForCreationDTO skillForCreationDTO)
            => Ok(await skillService.UpdateAsync(id, skillForCreationDTO));

        /// <summary>
        /// Get all skills
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await skillService.GetAll(@params));

        /// <summary>
        /// Get skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await skillService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await skillService.DeleteAsync(id));
    }
}
