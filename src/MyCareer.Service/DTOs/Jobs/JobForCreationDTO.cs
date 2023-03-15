using System.ComponentModel.DataAnnotations;
using MyCareer.Domain.Enums;

namespace MyCareer.Service.DTOs.Jobs
{
    public class JobForCreationDTO
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string CompanyName { get; set; }
        public RequiredLevel RequiredLevel { get; set; }
    }
}
