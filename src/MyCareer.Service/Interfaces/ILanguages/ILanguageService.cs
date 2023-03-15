using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Service.DTOs.Languages;

namespace MyCareer.Service.Interfaces.ILanguages
{
    public interface ILanguageService
    {
        IQueryable<Language> GetAll(PaginationParams @params, Expression<Func<Language, bool>> expression = null);
        ValueTask<Language> GetAsync(Expression<Func<Language, bool>> expression);
        ValueTask<Language> CreateAsync(LanguageForCreationDTO languageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Language Update(int Id, LanguageForCreationDTO languageForCreation);
    }
}
