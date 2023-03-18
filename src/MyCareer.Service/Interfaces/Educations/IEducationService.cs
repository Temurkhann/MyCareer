using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Service.DTOs.Educations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Educations
{
    public interface IEducationService
    {
        ValueTask<IEnumerable<Education>> GetAll(PaginationParams @params, Expression<Func<Education, bool>> expression = null);
        ValueTask<Education> GetAsync(Expression<Func<Education, bool>> expression);
        ValueTask<Education> CreateAsync(EducationForCreationDTO educationForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Education> Update(int Id, EducationForCreationDTO educationForCreationDTO);
    }
}
