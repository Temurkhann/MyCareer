using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Companies
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
        
        [Required]
        public int ContactId { get; set; }
    }
}
