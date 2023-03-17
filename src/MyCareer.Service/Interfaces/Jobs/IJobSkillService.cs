using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Jobs;
using MyCarrier.Domain.Entities.Jobs;

namespace MyCareer.Service.Interfaces.Jobs
{
    public interface IJobSkillService
    {
        ValueTask<IQueryable<JobSkill>> GetAll(PaginationParams @params, Expression<Func<JobSkill, bool>> expression = null);
        ValueTask<JobSkill> GetAsync(Expression<Func<JobSkill, bool>> expression);
        ValueTask<JobSkill> CreateAsync(JobSkillForCreationDTO jobForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<JobSkill> Update(int Id, JobSkillForCreationDTO jobSkillForCreation);
    }
}
