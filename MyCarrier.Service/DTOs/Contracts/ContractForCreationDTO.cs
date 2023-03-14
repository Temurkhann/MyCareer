using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Contracts
{
    public class ContractForCreationDTO
    {
        [Required]
        public int PerformerId { get; set; }
        
        [Required]
        public int CompanyWorkerId { get; set; }
        
        [Required]
        public string JobDetail { get; set; }
        
        [Required]
        public RequiredLevel Level { get; set; }
        
        [Required]
        public int DeadLine { get; set; }
    }
}
