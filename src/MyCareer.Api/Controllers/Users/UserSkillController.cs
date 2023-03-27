using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Interfaces.IUsers;
using MyCareer.Service.Services.Users;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillService userSkillService;

        public UserSkillController(IUserSkillService userSkillService)
        {
            this.userSkillService = userSkillService;
        }

        /// <summary>
        /// Create userSkill
        /// </summary>
        /// <param name="userSkillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserSkillForCreationDTO userSkillForCreationDTO)
            => Ok(await userSkillService.CreateAsync(userSkillForCreationDTO));

        /// <summary>
        /// Update userSkill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userSkillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserSkillForCreationDTO userSkillForCreationDTO)
            => Ok(await userSkillService.UpdateAsync(id, userSkillForCreationDTO));

        /// <summary>
        /// GetAll userSkills
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await userSkillService.GetAll(@params));

        /// <summary>
        /// Get userSkill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await userSkillService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete userSkill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await userSkillService.DeleteAsync(id));
    }
}
