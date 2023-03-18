using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Talents
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
