﻿using System.ComponentModel.DataAnnotations;
using System.IO;

namespace MyCareer.Service.DTOs.Attachments
{
    public class AttachmentForCreationDTO
    {
        [Required]
        public string Path { get; set; }

        public string Name { get; set; }

        [Required]
        public Stream Stream { get; set; }
    }
}
