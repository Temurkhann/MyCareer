using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Attachments
{
    public class AttachmentForCreationDTO
    {
        [Required]
        public string Path { get; set; }
    }
}
