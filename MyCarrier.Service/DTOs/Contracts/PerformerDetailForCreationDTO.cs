using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Contracts
{
    public class PerformerDetailForCreationDTO
    {
        [Required]
        public int FreelancerId { get; set; }
        
        [Required]
        public string PassportSerialNumber { get; set; }
        
        [Required]
        public string INN { get; set; }
        
        [Required]
        public string BankINN { get; set; }
        
        [Required]
        public string INPS { get; set; }
        
        [Required]
        public string MFO { get; set; }
        
        [Required]
        public string BankName { get; set; }
        
        [Required]
        public string TransitAccaunt { get; set; }
        
        [Required]
        public string CardNumber { get; set; }
    }
}
