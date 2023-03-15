﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Service.DTOs.Users;

namespace MyCareer.Service.Interfaces.IUsers
{
    public interface IUserLanguageService
    {
        ValueTask<IQueryable<UserLanguage>> GetAll(PaginationParams @params, Expression<Func<UserLanguage, bool>> expression = null);
        ValueTask<UserLanguage> GetAsync(Expression<Func<UserLanguage, bool>> expression);
        ValueTask<UserLanguage> CreateAsync(UserLanguageForCreationDTO userLanguageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserLanguage> Update(int Id, UserLanguageForCreationDTO userLanguageForCreation);
    }
}
