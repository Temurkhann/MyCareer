using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Contracts
{
    public class ContractSkillForCreationDTO
    {
        [Required]
        public int CompanyWorkerId { get; set; }
        
        [Required]
        public int RequiredSkillId { get; set; }
    }
}
