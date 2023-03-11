using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Entities.Contacts;

namespace MyCarrier.Domain.Entities.Companies
{
    public class CompanyInformation : Auditable
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string  Description { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
