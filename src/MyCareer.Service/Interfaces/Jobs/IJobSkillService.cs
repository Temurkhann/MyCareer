using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Service.DTOs.Jobs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Jobs
{
    public interface IJobSkillService
    {
        ValueTask<IEnumerable<JobSkill>> GetAll(PaginationParams @params, Expression<Func<JobSkill, bool>> expression = null);
        ValueTask<JobSkill> GetAsync(Expression<Func<JobSkill, bool>> expression);
        ValueTask<JobSkill> CreateAsync(JobSkillForCreationDTO jobForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<JobSkill> UpdateAsync(int id, JobSkillForCreationDTO jobSkillForCreation);
    }
}
