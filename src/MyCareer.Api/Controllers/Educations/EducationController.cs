using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Educations;
using MyCareer.Service.Interfaces.Educations;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Educations
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService educationService;

        public EducationController(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        /// <summary>
        /// Create new education
        /// </summary>
        /// <param name="educationForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost] 
        public async ValueTask<IActionResult> CreateAsync(EducationForCreationDTO educationForCreationDTO)
            => Ok(await educationService.CreateAsync(educationForCreationDTO));

        /// <summary>
        /// Update education
        /// </summary>
        /// <param name="id"></param>
        /// <param name="educationForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, EducationForCreationDTO educationForCreationDTO)
            => Ok(await educationService.Update(id, educationForCreationDTO));

        /// <summary>
        /// GetAll educations
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(await educationService.GetAll(@params));

        /// <summary>
        /// Get education
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await educationService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete education
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await educationService.DeleteAsync(id));
    }
}