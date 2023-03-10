using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Contracts
{
    public class Contract : Auditable
    {
        public int FreelancerId { get; set; }
        public int CompanyWorkerId { get; set; }
        public string JobDetail { get; set; }
    }
}
