using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Service.DTOs.Educations;
using MyCareer.Service.DTOs.Users;
using MyCarrier.Domain.Entities.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IEducations
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
