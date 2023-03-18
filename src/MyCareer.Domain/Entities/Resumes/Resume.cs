using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Attachments;

namespace MyCareer.Domain.Entities.Resumes
{
    public class Resume : Auditable
    {
        public string Name { get; set; }
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
    }
}
