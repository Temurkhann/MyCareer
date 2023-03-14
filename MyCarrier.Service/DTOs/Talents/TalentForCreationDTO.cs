using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Talents
{
    public class TalentForCreationDTO
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int SuccessJobs { get; set; }
        
        [Required]
        public int CompleteJobs { get; set; }
        
        [Required]
        public decimal HourIncome { get; set; }
    }
}
