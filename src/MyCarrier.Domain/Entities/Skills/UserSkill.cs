using MyCarrier.Domain.Commons;
using MyCarrier.Domain.Entities.Users;

namespace MyCarrier.Domain.Entities.Skills;

public class UserSkill : Auditable
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}