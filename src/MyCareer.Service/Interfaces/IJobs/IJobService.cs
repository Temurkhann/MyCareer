using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Service.DTOs.Jobs;

namespace MyCareer.Service.Interfaces.IJobs
{
    public interface IJobService
    {
        IQueryable<Job> GetAll(PaginationParams @params, Expression<Func<Job, bool>> expression = null);
        ValueTask<Job> GetAsync(Expression<Func<Job, bool>> expression);
        ValueTask<Job> CreateAsync(JobForCreationDTO jobForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Job Update(int Id, JobForCreationDTO jobForCreation);
    }
}