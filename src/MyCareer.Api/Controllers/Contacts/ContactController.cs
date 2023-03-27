using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.Interfaces.Contacts;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Contacts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        /// <summary>
        /// Create new contact
        /// </summary>
        /// <param name="contactForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(ContactForCreationDTO contactForCreationDTO)
            => Ok(await contactService.CreateAsync(contactForCreationDTO));


        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactForCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, ContactForCreationDTO contactForCreationDTO)
            => Ok(await contactService.Update(id, contactForCreationDTO));

        /// <summary>
        /// GetAll contacts
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await contactService.GetAll(@params));

        /// <summary>
        /// Get contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await contactService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await contactService.DeleteAsync(id));
    }
}
