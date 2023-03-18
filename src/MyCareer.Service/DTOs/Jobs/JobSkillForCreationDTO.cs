using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Jobs
{
    public class JobSkillForCreationDTO
    {
        [Required]
        public int JobId { get; set; }

        [Required]
        public int SkillId { get; set; }
    }
}
