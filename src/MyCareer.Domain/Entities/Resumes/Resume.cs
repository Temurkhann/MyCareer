using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Attachments;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Resumes
{
    public class Resume : Auditable
    {
        [MaxLength(64)]
        public string Name { get; set; }
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
    }
}
