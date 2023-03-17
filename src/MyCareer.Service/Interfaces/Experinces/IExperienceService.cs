﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Experiences;
using MyCareer.Service.DTOs.Experiences;

namespace MyCareer.Service.Interfaces.Experinces
{
    public interface IExperienceService
    {
        ValueTask<IQueryable<Experience>> GetAll(PaginationParams @params, Expression<Func<Experience, bool>> expression = null);
        ValueTask<Experience> GetAsync(Expression<Func<Experience, bool>> expression);
        ValueTask<Experience> CreateAsync(ExperienceForCreationDTO experienceForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Experience> Update(int Id, ExperienceForCreationDTO experienceForCreation);
    }
}
