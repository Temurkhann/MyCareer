using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Jobs;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Service.DTOs.Jobs;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.IJobs
{
    public interface IJobSkillService
    {
        IQueryable<JobSkill> GetAll(PaginationParams @params, Expression<Func<JobSkill, bool>> expression = null);
        ValueTask<JobSkill> GetAsync(Expression<Func<JobSkill, bool>> expression);
        ValueTask<JobSkill> CreateAsync(JobSkillForCreationDTO jobForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        JobSkill Update(int Id, JobSkillForCreationDTO jobSkillForCreation);
    }
}
