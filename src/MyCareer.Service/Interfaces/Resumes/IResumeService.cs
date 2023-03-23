using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Resumes;
using MyCareer.Service.DTOs.Resumes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Resumes
{
    public interface IResumeService
    {
        ValueTask<IEnumerable<Resume>> GetAll(PaginationParams @params, Expression<Func<Resume, bool>> expression = null);
        ValueTask<Resume> GetAsync(Expression<Func<Resume, bool>> expression);
        ValueTask<Resume> CreateAsync(ResumeForCreationDTO resumeForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Resume> Update(int id, ResumeForCreationDTO resumeForCreation);
    }
}
