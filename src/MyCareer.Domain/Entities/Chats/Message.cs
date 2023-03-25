using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Attachments;

namespace MyCareer.Domain.Entities.Chats
{
    public class Message : Auditable
    {
        public int MediaId { get; set; }
        public Attachment Media { get; set; }
        public string Content { get; set; }
    }
}
