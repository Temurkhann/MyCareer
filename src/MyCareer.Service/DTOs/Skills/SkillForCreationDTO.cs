using System.ComponentModel.DataAnnotations;
using MyCareer.Domain.Enums;

namespace MyCareer.Service.DTOs.Skills
{
    public class SkillForCreationDTO
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public Position Position { get; set; }
    }
}
