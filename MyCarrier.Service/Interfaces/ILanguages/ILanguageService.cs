using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Languages;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Service.DTOs.Languages;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.ILanguages
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
