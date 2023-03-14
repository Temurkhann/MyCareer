using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Experiences
{
    public class ExperienceForCreationDTO
    {
        [Required]
        public string CompanyName { get; set; }
        
        [Required]
        public string Job { get; set; }
        
        [Required]
        public DateTime DateFrom { get; set; }
        
        [Required]
        public DateTime DateTo { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int UserId { get; set; }
    }
}
