using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Resumes
{
    public class ResumeForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AttachmentId { get; set; }
    }
}
