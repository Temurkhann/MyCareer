using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Talents;
using MyCareer.Service.Interfaces.Talents;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Talents
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentController : ControllerBase
    {
        private readonly ITalentService talentService;

        public TalentController(ITalentService talentService)
        {
            this.talentService = talentService;
        }

        /// <summary>
        /// Create new talent
        /// </summary>
        /// <param name="talentForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(TalentForCreationDTO talentForCreationDTO)
            => Ok(await talentService.CreateAsync(talentForCreationDTO));

        /// <summary>
        /// Update talent
        /// </summary>
        /// <param name="id"></param>
        /// <param name="talentForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, TalentForCreationDTO talentForCreationDTO)
            => Ok(await talentService.UpdateAsync(id, talentForCreationDTO));

        /// <summary>
        /// GetAll talents
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await talentService.GetAll(@params));

        /// <summary>
        /// Get talent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await talentService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete talent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await talentService.DeleteAsync(id));
    }
}
