using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Skills
{
    public class Skill : Auditable
    {
        public string Content { get; set; }
        public Position Position { get; set; }
    }
}
