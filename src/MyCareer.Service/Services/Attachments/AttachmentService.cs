using MyCareer.Data.IRepositories;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Service.DTOs.Attachments;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Helpers;
using MyCareer.Service.Interfaces.Attachments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {

        private readonly IGenericRepository<Attachment> attachmentRepository;

        public AttachmentService(IGenericRepository<Attachment> attachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
        }

        public async ValueTask<Attachment> CreateAsync(string filePath)
        {

            var file = new Attachment()
            {
                Path = filePath
            };

            file = await attachmentRepository.CreateAsync(file);
            await attachmentRepository.SaveChangesAsync();

            return file;
        }

        public async ValueTask<Attachment> UpdateAsync(int id, Stream stream)
        {
            var existAttachment = await attachmentRepository.GetAsync(a => a.Id == id);

            if (existAttachment is null)
                throw new MyCareerException(404, "Attachment not found.");

            string fileName = existAttachment.Path;
            string filePath = Path.Combine(EnvironmentHelper.WebRootPath, fileName);

            // copy image to the destination as stream
            FileStream fileStream = File.OpenWrite(filePath);
            await stream.CopyToAsync(fileStream);

            // clear
            await fileStream.FlushAsync();
            fileStream.Close();

            await attachmentRepository.SaveChangesAsync();

            return existAttachment;
        }

        public async ValueTask<Attachment> UploadAsync(AttachmentForCreationDTO dto)
        {
            string fileName = Guid.NewGuid().ToString("N") + "png";
            string filePath = Path.Combine(EnvironmentHelper.AttachmentPath, fileName);

            if (!Directory.Exists(EnvironmentHelper.AttachmentPath))
                Directory.CreateDirectory(EnvironmentHelper.AttachmentPath);

            // copy image to the destination as stream
            FileStream fileStream = File.OpenWrite(filePath);
            await dto.Stream.CopyToAsync(fileStream);

            // clear
            await fileStream.FlushAsync();
            fileStream.Close();

            return await CreateAsync(Path.Combine(EnvironmentHelper.FilePath, fileName));
        }
    }
}
