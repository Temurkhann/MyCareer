using MyCarrier.Domain.Commons;
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
        public string FilePath { get; set; }
        public decimal Price { get; set; }
        public 

    }
}
