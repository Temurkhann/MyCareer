using System.ComponentModel.DataAnnotations;

namespace MyCareer.Service.DTOs.Chats
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
