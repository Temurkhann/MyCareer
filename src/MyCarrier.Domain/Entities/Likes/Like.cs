using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Likes
{
    public class Like : Auditable
    {
        public int TalentId { get; set; }
        public int UserId { get; set; }
    }
}
