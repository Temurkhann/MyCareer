using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;

namespace MyCareer.Domain.Entities.Chats
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
