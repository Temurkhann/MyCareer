using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Users
{
    public class UserLanguageService : IUserLanguageService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Language> languageRepository;
        private readonly IGenericRepository<UserLanguage> userLanguageRepository;
        private readonly IMapper mapper;

        public UserLanguageService(IGenericRepository<User> userRepository, IGenericRepository<Language> languageRepository, IGenericRepository<UserLanguage> userLanguageRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.languageRepository = languageRepository;
            this.userLanguageRepository = userLanguageRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserLanguage> CreateAsync(UserLanguageForCreationDTO userLanguageForCreationDTO)
        {
            var existLanguage = await languageRepository.GetAsync(
                  c => c.Id == userLanguageForCreationDTO.LanguageId);

            if (existLanguage == null)
                throw new MyCareerException(404, "No language found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == userLanguageForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "No user found");

            var createdUserLanguage = await userLanguageRepository.CreateAsync(mapper.Map<UserLanguage>(userLanguageForCreationDTO));
            await userLanguageRepository.SaveChangesAsync();

            return createdUserLanguage;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await userLanguageRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "UserLanguage not found");

            await userLanguageRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<UserLanguage>> GetAll(PaginationParams @params, Expression<Func<UserLanguage, bool>> expression = null)
        {
            var userLanguages = userLanguageRepository.GetAll(expression: expression, isTracking: false);

            return await userLanguages.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<UserLanguage> GetAsync(Expression<Func<UserLanguage, bool>> expression)
        {
            var userLanguage = await userLanguageRepository.GetAsync(expression, false, new string[] { "User", "Language" });

            if (userLanguage is null)
                throw new MyCareerException(404, "UserLanguage not found");

            return userLanguage;
        }

        public async ValueTask<UserLanguage> Update(int id, UserLanguageForCreationDTO userLanguageForCreation)
        {
            var existUserLanguage = await userLanguageRepository.GetAsync(f => f.Id == id);

            if (existUserLanguage is null)
                throw new MyCareerException(404, "UserLanguage not found");

            var existlanguage = await languageRepository.GetAsync(
                c => c.Id == userLanguageForCreation.LanguageId);

            if (existlanguage == null)
                throw new MyCareerException(404, "Language not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == userLanguageForCreation.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            existUserLanguage.UpdatedAt = DateTime.UtcNow;
            existUserLanguage = userLanguageRepository.Update(mapper.Map(userLanguageRepository, existUserLanguage));
            await userLanguageRepository.SaveChangesAsync();

            return existUserLanguage;
        }
    }
}
