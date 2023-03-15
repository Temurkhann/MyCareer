using MyCareer.Domain.Commons;

namespace MyCareer.Domain.Entities.Attachments
{
    public class Attachment : Auditable
    {
        public string Path { get; set; }
    }
}
