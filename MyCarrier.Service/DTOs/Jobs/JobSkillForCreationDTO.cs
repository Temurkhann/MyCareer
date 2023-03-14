using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Jobs
{
    public class JobSkillForCreationDTO
    {
        [Required]
        public int JobId { get; set; }
        
        [Required]
        public int SkillId { get; set; }
    }
}
