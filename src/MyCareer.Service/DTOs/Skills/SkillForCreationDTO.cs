using MyCareer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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
