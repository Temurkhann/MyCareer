using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Jobs;
using MyCareer.Service.Interfaces.Jobs;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Jobs
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        /// <summary>
        /// Create new job
        /// </summary>
        /// <param name="jobForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(JobForCreationDTO jobForCreationDTO)
            => Ok(await jobService.CreateAsync(jobForCreationDTO));

        /// <summary>
        /// Update job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, JobForCreationDTO jobForCreationDTO)
            => Ok(await jobService.UpdateAsync(id, jobForCreationDTO));

        /// <summary>
        /// GetAll jobs
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet] 
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await jobService.GetAll(@params));

        /// <summary>
        /// Get job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await jobService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await jobService.DeleteAsync(id));
    }
}