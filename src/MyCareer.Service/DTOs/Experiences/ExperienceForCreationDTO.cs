using System;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Experiences
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
