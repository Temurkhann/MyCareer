using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Contracts
{
    public class PerformerDetails : Auditable
    {
        public int FreelancerId { get; set; }
        public string PassportSerialNumber { get; set; }
        public string INN { get; set; }
        public string BankINN { get; set; }
        public string INPS { get; set; }
        public string MFO { get; set; }
        public string BankName { get; set; }
        public string TransitAccaunt { get; set; }
        public string CardNumber { get; set; }
    }
}
