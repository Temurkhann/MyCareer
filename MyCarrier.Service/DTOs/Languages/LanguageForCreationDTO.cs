using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Languages
{
    public class LanguageForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public Level Level { get; set; }
    }
}
