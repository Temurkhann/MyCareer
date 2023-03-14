using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.IResumes
{
    public interface IResumeService
    {
        IQueryable<Resume> GetAll(PaginationParams @params, Expression<Func<Resume, bool>> expression = null);
        ValueTask<Resume> GetAsync(Expression<Func<Resume, bool>> expression);
        ValueTask<Resume> CreateAsync(ResumeForCreationDTO resumeForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Resume Update(int Id, ResumeForCreationDTO resumeForCreation);
    }
}
