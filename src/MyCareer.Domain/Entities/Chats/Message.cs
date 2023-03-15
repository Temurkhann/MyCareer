using MyCareer.Domain.Commons;

namespace MyCareer.Domain.Entities.Chats
{
    public class Message : Auditable
    {
        public string Media { get; set; }
        public string Content { get; set; }
    }
}
