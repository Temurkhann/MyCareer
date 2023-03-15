using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Users;

namespace MyCareer.Domain.Entities.Hobbies
{
    public class UserHobby : Auditable
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
        public string OtherHobby { get; set; }
    }
}
