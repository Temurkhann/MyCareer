using Microsoft.AspNetCore.Http;
using MyCareer.Service.DTOs.Attachments;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Resumes
{
    public class ResumeForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile FormFile { get; set; }
    }
}
