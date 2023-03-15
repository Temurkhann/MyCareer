using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Domain.Enums;

namespace MyCareer.Domain.Entities.Contracts
{
    public class Contract : Auditable
    {
        public int PerformerId { get; set; }
        public Freelancer Performer { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string JobDetail { get; set; }
        public RequiredLevel Level { get; set; }
        public int DeadLine { get; set; }
    }
}
