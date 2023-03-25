using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Experiences;
using MyCareer.Service.DTOs.Experiences;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Experiences
{
    public interface IExperienceService
    {
        ValueTask<IEnumerable<Experience>> GetAll(PaginationParams @params, Expression<Func<Experience, bool>> expression = null);
        ValueTask<Experience> GetAsync(Expression<Func<Experience, bool>> expression);
        ValueTask<Experience> CreateAsync(ExperienceForCreationDTO experienceForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Experience> Update(int id, ExperienceForCreationDTO experienceForCreation);
    }
}
