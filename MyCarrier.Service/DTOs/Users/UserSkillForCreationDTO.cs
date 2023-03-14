using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Users
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
