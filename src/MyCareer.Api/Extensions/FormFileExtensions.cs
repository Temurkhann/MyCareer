using Microsoft.AspNetCore.Http;
using MyCareer.Service.DTOs.Attachments;
using System.IO;

namespace MyCareer.Api.Extensions
{
    public static class FormFileExtensions
    {
        public static AttachmentForCreationDTO ToAttachmentOrDefault(this IFormFile formFile)
        {

            if (formFile?.Length > 0)
            {
                using var ms = new MemoryStream();
                formFile.CopyTo(ms);
                var fileBytes = ms.ToArray();

                return new AttachmentForCreationDTO()
                {
                    Name = formFile.FileName,
                    Stream = new MemoryStream(fileBytes)
                };
            }

            return null;
        }
    }
}
