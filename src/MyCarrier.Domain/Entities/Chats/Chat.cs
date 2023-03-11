using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Entities.Companies;
using MyCarrier.Domain.Entities.Freelancers;

namespace MyCarrier.Domain.Entities.Chats
{
    public class Chat : Auditable
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}
