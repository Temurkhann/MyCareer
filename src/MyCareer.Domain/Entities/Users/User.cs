using MyCareer.Domain.Commons;

namespace MyCareer.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
