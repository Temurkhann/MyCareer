using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Languages
{
    public class Language : Auditable
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public Level Level { get; set; }
    }
}
