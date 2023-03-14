using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.DTOs.Chats
{
    public class ChatForCreationDTO
    {
        [Required]
        public int FreelancerId { get; set; }
        
        [Required]
        public int CompanyId { get; set; }
        
        [Required]
        public int MessageId { get; set; }
    }
}
