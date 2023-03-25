using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Jobs;
using MyCareer.Service.Interfaces.Jobs;

namespace MyCareer.Api.Controllers.Jobs
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSkillController : ControllerBase
    {
        private readonly IJobSkillService jobSkillService;

        public JobSkillController(IJobSkillService jobSkillService)
        {
            this.jobSkillService = jobSkillService;
        }

        /// <summary>
        /// Create new JobSkill
        /// </summary>
        /// <param name="jobSkillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(JobSkillForCreationDTO jobSkillForCreationDTO)
            => Ok(await jobSkillService.CreateAsync(jobSkillForCreationDTO));

        /// <summary>
        /// Update JobSkill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobSkillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, JobSkillForCreationDTO jobSkillForCreationDTO)
            => Ok(await jobSkillService.Update(id, jobSkillForCreationDTO));

        /// <summary>
        /// GetAll JobSkills
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(await jobSkillService.GetAll(@params));

        /// <summary>
        /// Get JobSkill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await jobSkillService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete JobSkill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await jobSkillService.DeleteAsync(id));
    }
}