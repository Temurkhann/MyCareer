using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Contracts
{
    public class ContractSkillForCreationDTO
    {
        [Required]
        public int CompanyWorkerId { get; set; }
        
        [Required]
        public int RequiredSkillId { get; set; }
    }
}
