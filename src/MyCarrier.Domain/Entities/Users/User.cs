using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Commons;

namespace MyCarrier.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string Email { get; set; }   
        public string Password { get; set; }
    }
}
