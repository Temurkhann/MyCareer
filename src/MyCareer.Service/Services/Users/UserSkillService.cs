using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.IUsers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Users
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Skill> skillRepository;
        private readonly IGenericRepository<UserSkill> userSkillRepository;
        private readonly IMapper mapper;

        public UserSkillService(IGenericRepository<User> userRepository, IGenericRepository<Skill> skillRepository, IGenericRepository<UserSkill> userSkillRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.skillRepository = skillRepository;
            this.userSkillRepository = userSkillRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserSkill> CreateAsync(UserSkillForCreationDTO userSkillForCreationDTO)
        {
            var existSkill = await skillRepository.GetAsync(
                  c => c.Id == userSkillForCreationDTO.SkillId);

            if (existSkill == null)
                throw new MyCareerException(404, "Skill not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == userSkillForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            var createdUserLanguage = await userSkillRepository.CreateAsync(mapper.Map<UserSkill>(userSkillForCreationDTO));
            await userSkillRepository.SaveChangesAsync();

            return createdUserLanguage;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await userSkillRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "UserSkill not found");

            await userSkillRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<UserSkill>> GetAll(PaginationParams @params, Expression<Func<UserSkill, bool>> expression = null)
        {
            var userSkills = userSkillRepository.GetAll(expression: expression, isTracking: false);

            return await userSkills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<UserSkill> GetAsync(Expression<Func<UserSkill, bool>> expression)
        {
            var userLanguage = await userSkillRepository.GetAsync(expression, false, new string[] { "User", "Skill" });

            if (userLanguage is null)
                throw new MyCareerException(404, "UserSkill not found");

            return userLanguage;
        }

        public async ValueTask<UserSkill> UpdateAsync(int id, UserSkillForCreationDTO userSkillForCreation)
        {
            var existUserSkill = await userSkillRepository.GetAsync(f => f.Id == id);

            if (existUserSkill is null)
                throw new MyCareerException(404, "UserSkill not found");

            var existSkill = await skillRepository.GetAsync(
                c => c.Id == userSkillForCreation.SkillId);

            if (existSkill == null)
                throw new MyCareerException(404, "Skill not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == userSkillForCreation.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            existUserSkill.UpdatedAt = DateTime.UtcNow;
            existUserSkill = userSkillRepository.Update(mapper.Map(userSkillRepository, existUserSkill));
            await userSkillRepository.SaveChangesAsync();

            return existUserSkill;
        }
    }
}