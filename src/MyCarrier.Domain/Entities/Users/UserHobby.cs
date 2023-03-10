using MyCarrier.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Domain.Entities.Users
{
    public class UserHobby : Auditable
    {
        public int UserId { get; set; }
        public int HobbyId { get; set; }
        public string OtherHobby { get; set; }
    }
}
