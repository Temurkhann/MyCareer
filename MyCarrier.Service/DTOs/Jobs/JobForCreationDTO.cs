using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Jobs
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
