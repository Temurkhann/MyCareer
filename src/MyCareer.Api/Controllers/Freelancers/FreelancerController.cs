using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.Interfaces.Freelancers;
using MyCareer.Service.Services.Resumes;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Freelancers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IFreelancerService freelancerService;

        public FreelancerController(IFreelancerService freelancerService)
        {
            this.freelancerService = freelancerService;
        }

        /// <summary>
        /// Create new freelancer
        /// </summary>
        /// <param name="freelancerForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(FreelancerForCreationDTO freelancerForCreationDTO)
            => Ok(await freelancerService.CreateAsync(freelancerForCreationDTO));

        /// <summary>
        /// Update freelancer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="freelancerForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, FreelancerForCreationDTO freelancerForCreationDTO)
            => Ok(await freelancerService.UpdateAsync(id, freelancerForCreationDTO));

        /// <summary>
        /// GetAll freelancers
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await freelancerService.GetAll(@params));

        /// <summary>
        /// Get freelancer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await freelancerService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete freelancer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await freelancerService.DeleteAsync(id));
    }
}
