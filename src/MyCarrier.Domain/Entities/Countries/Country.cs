using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Countries
{
    public class Country : Auditable
    {
        public string Name { get; set; }
    }
}
