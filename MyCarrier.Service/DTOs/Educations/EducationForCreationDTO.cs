using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Educations
{
    public class EducationForCreationDTO
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public Degree Degree { get; set; }
        
        [Required]
        public TypeOfStudy TypeOfStudy { get; set; }
        
        [Required]
        public string Location { get; set; }
        
        [Required]
        public DateTime DateFrom { get; set; }
        
        [Required]
        public DateTime DateTo { get; set; }
        
        [Required]
        public int UserId { get; set; }
    }
}
