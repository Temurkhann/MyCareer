using MyCarier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarier.Domain.Entities.Chats
{
    public class Chat : Auditable
    {
        public string Member { get; set; }
    }
}
