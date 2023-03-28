using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Service.DTOs.Attachments;

namespace MyCareer.Service.DTOs.Chats
{
    public class MessageForCreationDTO
    {
        public int MediaId { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
