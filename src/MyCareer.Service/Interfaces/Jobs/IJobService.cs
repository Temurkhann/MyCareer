using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Service.DTOs.Jobs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Jobs
{
    public interface IJobService
    {
        ValueTask<IEnumerable<Job>> GetAll(PaginationParams @params, Expression<Func<Job, bool>> expression = null);
        ValueTask<Job> GetAsync(Expression<Func<Job, bool>> expression);
        ValueTask<Job> CreateAsync(JobForCreationDTO jobForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Job> Update(int id, JobForCreationDTO jobForCreation);
    }
}