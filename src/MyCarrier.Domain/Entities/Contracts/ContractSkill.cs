using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Contracts
{
    public class ContractSkill : Auditable
    {
        public int CompanyWorkerId { get; set; }
        public int RequiredSkillId { get; set; }
    }
}
