using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Jobs
{
    public class Job : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public RequiredLevel RequiredLevel { get; set; }
    }
}
