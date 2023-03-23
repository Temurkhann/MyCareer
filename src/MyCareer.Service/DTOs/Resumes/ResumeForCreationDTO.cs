using MyCareer.Service.DTOs.Attachments;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Resumes
{
    public class ResumeForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public AttachmentForCreationDTO Attachment { get; set; }
    }
}
