using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Talents;

namespace MyCareer.Domain.Entities.Likes
{
    public class Like : Auditable
    {
        public int TalentId { get; set; }
        public Talent Talent { get; set; }
        public int UserId { get; set; }
    }
}
