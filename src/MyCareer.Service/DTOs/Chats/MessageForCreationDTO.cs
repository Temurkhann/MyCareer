using MyCareer.Domain.Entities.Attachments;
using MyCareer.Service.DTOs.Attachments;

namespace MyCareer.Service.DTOs.Chats
{
    public class MessageForCreationDTO
    {
        public int ChatId { get; set; }
        public AttachmentForCreationDTO Media { get; set; }
        public string Content { get; set; }
    }
}
