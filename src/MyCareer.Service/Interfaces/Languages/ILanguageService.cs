using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Service.DTOs.Languages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Languages
{
    public interface ILanguageService
    {
        ValueTask<IEnumerable<Language>> GetAll(PaginationParams @params, Expression<Func<Language, bool>> expression = null);
        ValueTask<Language> GetAsync(Expression<Func<Language, bool>> expression);
        ValueTask<Language> CreateAsync(LanguageForCreationDTO languageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Language> Update(int Id, LanguageForCreationDTO languageForCreation);
    }
}
