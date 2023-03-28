using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;
using System.Collections.Generic;

namespace MyCareer.Domain.Entities.Chats
{
    public class Chat : Auditable
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Message> FreelancerMessages { get; set; }
    }
}
