using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Experiences;
using MyCarrier.Domain.Entities.Freelancers;
using MyCarrier.Service.DTOs.Experiences;
using MyCarrier.Service.DTOs.Freelancers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.IExperinces
{
    public interface IExperienceService
    {
        IQueryable<Experience> GetAll(PaginationParams @params, Expression<Func<Experience, bool>> expression = null);
        ValueTask<Experience> GetAsync(Expression<Func<Experience, bool>> expression);
        ValueTask<Experience> CreateAsync(ExperienceForCreationDTO experienceForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Experience Update(int Id, ExperienceForCreationDTO experienceForCreation);
    }
}
