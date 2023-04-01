using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace MyCareer.Domain.Entities.Contracts
{
    public class PerformerDetails : Auditable
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        [MaxLength(16)]
        public string PassportSerialNumber { get; set; }

        [MaxLength(9)]
        public string INN { get; set; }

        [MaxLength(20)]
        public string BankINN { get; set; }

        [MaxLength(14)]
        public string INPS { get; set; }
        
        [MaxLength(5)]
        public string MFO { get; set; }

        [MaxLength(64)]
        public string BankName { get; set; }
        
        [MaxLength(20)]
        public string TransitAccount { get; set; }
        
        [MaxLength(16), CreditCard]
        public string CardNumber { get; set; }
    }
}
