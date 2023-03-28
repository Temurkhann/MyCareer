using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Companies;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.Extensions;
using MyCareer.Service.Interfaces.Companies;
using MyCareer.Service.Services.Resumes;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        /// <summary>
        /// Create new company
        /// </summary>
        /// <param name="companyForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CompanyForCreationDTO companyForCreationDTO)
            => Ok(await companyService.CreateAsync(companyForCreationDTO));

        /// <summary>
        /// Update company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id,[FromForm] CompanyForCreationDTO companyForCreationDTO)
            => Ok(await companyService.UpdateAsync(id, companyForCreationDTO));

        /// <summary>
        /// GetAll companies
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await companyService.GetAll(@params));

        /// <summary>
        /// Get company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await companyService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await companyService.DeleteAsync(id));

        [HttpPatch("{id}/image")]
        public async ValueTask<IActionResult> AddAttachmnetAsync([FromRoute] int id, IFormFile formFile) =>
            Ok(await companyService.CreateAttachmentAsync(id,formFile.ToAttachmentOrDefault()));
    }
}
