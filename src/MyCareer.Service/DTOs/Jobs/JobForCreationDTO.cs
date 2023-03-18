using MyCareer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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
