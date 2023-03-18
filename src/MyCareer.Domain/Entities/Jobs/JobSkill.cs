using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCareer.Domain.Commons;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Domain.Entities.Skills;
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
