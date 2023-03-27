using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.DTOs.Talents;
using MyCareer.Service.Interfaces.Resumes;
using MyCareer.Service.Interfaces.Talents;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Resumes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService resumeService;

        public ResumeController(IResumeService resumeService)
        {
            this.resumeService = resumeService;
        }

        /// <summary>
        /// Create new resume
        /// </summary>
        /// <param name="resumeForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(ResumeForCreationDTO resumeForCreationDTO)
            => Ok(await resumeService.CreateAsync(resumeForCreationDTO));

        /// <summary>
        /// Update resume
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resumeForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, ResumeForCreationDTO resumeForCreationDTO)
            => Ok(await resumeService.Update(id, resumeForCreationDTO));

        /// <summary>
        /// GetAll resumes
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await resumeService.GetAll(@params));

        /// <summary>
        /// Get resume
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await resumeService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete resume
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await resumeService.DeleteAsync(id));
    }
}
