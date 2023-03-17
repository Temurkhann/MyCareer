using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Service.DTOs.Educations;

namespace MyCareer.Service.Interfaces.Educations
{
    public interface IEducationService
    {
        ValueTask<IQueryable<Education>> GetAll(PaginationParams @params, Expression<Func<Education, bool>> expression = null);
        ValueTask<Education> GetAsync(Expression<Func<Education, bool>> expression);
        ValueTask<Education> CreateAsync(EducationForCreationDTO educationForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Education> Update(int Id, EducationForCreationDTO educationForCreationDTO);
    }
}
