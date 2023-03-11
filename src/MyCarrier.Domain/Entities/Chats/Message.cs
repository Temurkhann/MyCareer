using MyCarrier.Domain.Commons;

namespace MyCarrier.Domain.Entities.Chats
{
    public class Message : Auditable
    {
        public string Media { get; set; }
        public string Content { get; set; }
    }
}
