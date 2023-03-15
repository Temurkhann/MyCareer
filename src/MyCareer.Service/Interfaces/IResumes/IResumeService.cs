using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Resumes;
using MyCareer.Service.DTOs.Resumes;

namespace MyCareer.Service.Interfaces.IResumes
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
