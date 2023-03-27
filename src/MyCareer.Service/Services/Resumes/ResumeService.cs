using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Resumes;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.Interfaces.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Resumes
{
    public class ResumeService : IResumeService
    {
        public ValueTask<Resume> CreateAsync(ResumeForCreationDTO resumeForCreationDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Resume>> GetAll(PaginationParams @params, Expression<Func<Resume, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Resume> GetAsync(Expression<Func<Resume, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Resume> UpdateAsync(int id, ResumeForCreationDTO resumeForCreation)
        {
            throw new NotImplementedException();
        }
    }
}
