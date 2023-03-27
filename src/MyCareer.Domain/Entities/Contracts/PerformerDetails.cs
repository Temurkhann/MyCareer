using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;

namespace MyCareer.Domain.Entities.Contracts
{
    public class PerformerDetails : Auditable
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public string PassportSerialNumber { get; set; }
        public string INN { get; set; }
        public string BankINN { get; set; }
        public string INPS { get; set; }
        public string MFO { get; set; }
        public string BankName { get; set; }
        public string TransitAccount { get; set; }
        public string CardNumber { get; set; }
    }
}
