using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Resumes
{
    public class ResumeForCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AttachmentId { get; set; }
    }
}
