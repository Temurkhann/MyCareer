using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Entities.Companies;
using MyCarrier.Domain.Entities.Freelancers;

namespace MyCarrier.Domain.Entities.Contracts
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
