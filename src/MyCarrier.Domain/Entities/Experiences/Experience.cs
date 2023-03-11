using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Entities.Users;

namespace MyCarrier.Domain.Entities.Experiences
{
    public class Experience : Auditable
    {
        public string CompanyName { get; set; }
        public string Job { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
