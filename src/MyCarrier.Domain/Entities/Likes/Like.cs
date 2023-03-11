using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarrier.Domain.Entities.Talents;

namespace MyCarrier.Domain.Entities.Likes
{
    public class Like : Auditable
    {
        public int TalentId { get; set; }
        public Talent Talent { get; set; }
        public int UserId { get; set; }
    }
}
