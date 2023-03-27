using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCareer.Api.Extensions;
using MyCareer.Service.Interfaces.Attachments;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Attachments
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService attachmentService;

        public AttachmentController(IAttachmentService attachmentService)
        {
            this.attachmentService = attachmentService;
        }

        /// <summary>
        /// Create new attachment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> UploadAsync(IFormFile formFile)
            => Ok(await attachmentService.UploadAsync(formFile.ToAttachmentOrDefault()));

        /// <summary>
        /// Update attachment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, IFormFile formFile)
            => Ok(await attachmentService.UpdateAsync(id, formFile.ToAttachmentOrDefault().Stream));
    }
}
