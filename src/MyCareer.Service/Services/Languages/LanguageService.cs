using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Service.DTOs.Languages;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IGenericRepository<Language> languageRepository;
        private readonly IMapper mapper;

        public LanguageService(IGenericRepository<Language> languageRepository, IMapper mapper)
        {
            this.languageRepository = languageRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Language> CreateAsync(LanguageForCreationDTO languageForCreationDTO)
        {
            var createdUserHobby = await languageRepository.CreateAsync(mapper.Map<Language>(languageForCreationDTO));
            await languageRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await languageRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Skill not found");

            await languageRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Language>> GetAll(PaginationParams @params, Expression<Func<Language, bool>> expression = null)
        {
            var skills = languageRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User" });

            return await skills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Language> GetAsync(Expression<Func<Language, bool>> expression)
        {
            var skill = await languageRepository.GetAsync(expression, false);

            if (skill is null)
                throw new MyCareerException(404, "UserHobby not found");

            return skill;
        }

        public async ValueTask<Language> UpdateAsync(int id, LanguageForCreationDTO languageForCreation)
        {
            var existSkill = await languageRepository.GetAsync(f => f.Id == id);

            if (existSkill is null)
                throw new MyCareerException(404, "No Talent was found");

            existSkill.UpdatedAt = DateTime.UtcNow;
            existSkill = languageRepository.Update(mapper.Map(languageForCreation, existSkill));
            await languageRepository.SaveChangesAsync();

            return existSkill;
        }
    }
}
