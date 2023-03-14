using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Skills
{
    public class SkillForCreationDTO
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public Position Position { get; set; }
    }
}
