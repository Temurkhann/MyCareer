using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Addresses
{
    public class Address : Auditable
    {
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public string Street { get; set; }
    }
}
