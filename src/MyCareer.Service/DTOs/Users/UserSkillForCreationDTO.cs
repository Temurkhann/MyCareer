using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Users
{
    public class UserSkillForCreationDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int SkillId { get; set; }
        public string OtherSkills { get; set; }
    }
}
