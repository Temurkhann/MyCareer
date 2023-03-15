using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Attachments
{
    public class AttachmentForCreationDTO
    {
        [Required]
        public string Path { get; set; }
    }
}
