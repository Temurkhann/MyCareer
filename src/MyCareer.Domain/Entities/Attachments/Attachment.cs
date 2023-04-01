using MyCareer.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Attachments
{
    public class Attachment : Auditable
    {
        [MaxLength(256)]
        public string Path { get; set; }
    }
}
