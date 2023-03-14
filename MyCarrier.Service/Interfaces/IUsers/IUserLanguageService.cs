using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.Users
{
    public interface IUserLanguageService
    {
        IQueryable<UserLanguage> GetAll(PaginationParams @params, Expression<Func<UserLanguage, bool>> expression = null);
        ValueTask<UserLanguage> GetAsync(Expression<Func<UserLanguage, bool>> expression);
        ValueTask<UserLanguage> CreateAsync(UserLanguageForCreationDTO userLanguageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        UserLanguage Update(int Id, UserLanguageForCreationDTO userLanguageForCreation);
    }
}
