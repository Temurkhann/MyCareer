using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.Interfaces.Contracts;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Contracts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractSkillController : ControllerBase
    {
        private readonly IContractSkillService contractSkillService;

        public ContractSkillController(IContractSkillService contractSkillService)
        {
            this.contractSkillService = contractSkillService;
        }

        /// <summary>
        /// Create new contractSkill
        /// </summary>
        /// <param name="contractSkillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(ContractSkillForCreationDTO contractSkillForCreationDTO)
            => Ok(await contractSkillService.CreateAsync(contractSkillForCreationDTO));

        /// <summary>
        /// Update contractSkill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractSkillForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, ContractSkillForCreationDTO contractSkillForCreationDTO)
            => Ok(await contractSkillService.Update(id, contractSkillForCreationDTO));

        /// <summary>
        /// GetAll contractSkills
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await contractSkillService.GetAll(@params));

        /// <summary>
        /// Get contractSkill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await contractSkillService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete contractSkill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await contractSkillService.DeleteAsync(id));
    }
}
