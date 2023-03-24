using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Service.DTOs.Jobs;
using MyCareer.Service.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Jobs
{
    public class JobSkillService : IJobSkillService
    {
        public ValueTask<JobSkill> CreateAsync(JobSkillForCreationDTO jobForCreationDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<JobSkill>> GetAll(PaginationParams @params, Expression<Func<JobSkill, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<JobSkill> GetAsync(Expression<Func<JobSkill, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<JobSkill> Update(int id, JobSkillForCreationDTO jobSkillForCreation)
        {
            throw new NotImplementedException();
        }
    }
}
