using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Skills;

namespace MyCareer.Domain.Entities.Jobs
{
    public class JobSkill : Auditable
    {
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
