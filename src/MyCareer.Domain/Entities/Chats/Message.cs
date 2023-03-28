using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Domain.Entities.Chats
{
    public class Message : Auditable
    {
        public int MediaId { get; set; }
        public Attachment Media { get; set; }
        public string Content { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int UserId { get; set; }
        public User Freelancer { get; set; }
    }
}
