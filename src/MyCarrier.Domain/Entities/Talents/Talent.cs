using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Talents
{
    public class Talent : Auditable
    {
        public int UserId { get; set; }
        public int SuccessJobs { get; set; }
        public int CompleteJobs { get; set; }
        public decimal HourIncome { get; set; }
    }
}
