using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Skills;

namespace MyCareer.Domain.Entities.Users;

public class UserSkill : Auditable
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}