using MyCarier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarier.Domain.Entities.Companies
{
    public class Company : Auditable
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
