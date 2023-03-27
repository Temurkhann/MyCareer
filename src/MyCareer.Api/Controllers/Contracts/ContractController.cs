using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.Interfaces.Contracts;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Contracts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService contractService;

        public ContractController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        /// <summary>
        /// Create new contract
        /// </summary>
        /// <param name="contractForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(ContractForCreationDTO contractForCreationDTO)
            => Ok(await contractService.CreateAsync(contractForCreationDTO));

        /// <summary>
        /// Update contract
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contractForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, ContractForCreationDTO contractForCreationDTO)
            => Ok(await contractService.UpdateAsync(id, contractForCreationDTO));

        /// <summary>
        /// GetAll contracts
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await contractService.GetAll(@params));

        /// <summary>
        /// Get contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await contractService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await contractService.DeleteAsync(id));
    }
}
