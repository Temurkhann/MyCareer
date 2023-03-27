using MyCareer.Service.DTOs.Contacts;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Companies
{
    public class CompanyInformationForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }
        public ContactForCreationDTO Contact { get; set; }
    }
}
