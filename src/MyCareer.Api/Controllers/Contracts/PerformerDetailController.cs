using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.Interfaces.Contracts;
using MyCareer.Service.Services.Contracts;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Contracts
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerDetailController : ControllerBase
    {
        private readonly IPerformerDetailService performerDetailService;

        public PerformerDetailController(IPerformerDetailService performerDetailService)
        {
            this.performerDetailService = performerDetailService;
        }

        /// <summary>
        /// Create new performerDetail
        /// </summary>
        /// <param name="performerDetailForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(PerformerDetailForCreationDTO performerDetailForCreationDTO)
            => Ok(await performerDetailService.CreateAsync(performerDetailForCreationDTO));

        /// <summary>
        /// Update performerDetail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="performerDetailForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, PerformerDetailForCreationDTO performerDetailForCreationDTO)
            => Ok(await performerDetailService.UpdateAsync(id, performerDetailForCreationDTO));

        /// <summary>
        /// DetAll performerDetails
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await performerDetailService.GetAll(@params));

        /// <summary>
        /// Get performerDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await performerDetailService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete performerDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await performerDetailService.DeleteAsync(id));
    }
}
