using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Users
{
    public class UserContact : Auditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageText { get; set; }
        public string PhoneNumber { get; set; }
    }
}
