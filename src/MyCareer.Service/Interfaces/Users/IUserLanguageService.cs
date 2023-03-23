using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Users
{
    public interface IUserLanguageService
    {
        ValueTask<IEnumerable<UserLanguage>> GetAll(PaginationParams @params, Expression<Func<UserLanguage, bool>> expression = null);
        ValueTask<UserLanguage> GetAsync(Expression<Func<UserLanguage, bool>> expression);
        ValueTask<UserLanguage> CreateAsync(UserLanguageForCreationDTO userLanguageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserLanguage> Update(int id, UserLanguageForCreationDTO userLanguageForCreation);
    }
}
