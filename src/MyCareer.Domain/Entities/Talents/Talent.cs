using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;

namespace MyCareer.Domain.Entities.Talents
{
    public class Talent : Auditable
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int SuccessJobs { get; set; }
        public int CompleteJobs { get; set; }
        public decimal HourIncome { get; set; }
    }
}
