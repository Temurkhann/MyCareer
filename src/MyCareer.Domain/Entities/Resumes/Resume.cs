using MyCareer.Domain.Commons;

namespace MyCareer.Domain.Entities.Resumes
{
    public class Resume : Auditable
    {
        public string Name { get; set; }
        public int AttachmentId { get; set; }
    }
}
