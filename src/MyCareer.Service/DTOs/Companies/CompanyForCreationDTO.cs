using MyCareer.Service.DTOs.Attachments;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Companies
{
    public class CompanyForCreationDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public CompanyInformationForCreationDTO CompanyInformation { get; set; }
    }
}
