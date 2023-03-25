using MyCareer.Domain.Entities.Attachments;
using MyCareer.Service.DTOs.Attachments;
using System.IO;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Attachments
{
    public interface IAttachmentService
    {
        ValueTask<Attachment> UploadAsync(int questionId, AttachmentForCreationDTO dto);
        ValueTask<Attachment> UpdateAsync(int id, Stream stream);
        ValueTask<Attachment> CreateAsync(int questionId, string fileName, string filePath);
    }
}
