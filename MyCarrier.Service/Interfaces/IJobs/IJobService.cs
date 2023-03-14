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
    public interface IJobService
    {
        IQueryable<Job> GetAll(PaginationParams @params, Expression<Func<Job, bool>> expression = null);
        ValueTask<Job> GetAsync(Expression<Func<Job, bool>> expression);
        ValueTask<Job> CreateAsync(JobForCreationDTO jobForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Job Update(int Id, JobForCreationDTO jobForCreation);
    }
}