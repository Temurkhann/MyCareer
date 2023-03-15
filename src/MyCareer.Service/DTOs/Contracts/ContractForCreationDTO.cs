using System.ComponentModel.DataAnnotations;
using MyCareer.Domain.Enums;

namespace MyCareer.Service.DTOs.Contracts
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
