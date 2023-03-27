using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Domain.Entities.Talents;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.DTOs.Talents;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly IGenericRepository<Skill> skillRepository;
        private readonly IMapper mapper;

        public SkillService(IGenericRepository<Skill> skillRepository, IMapper mapper)
        {
            this.skillRepository = skillRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Skill> CreateAsync(SkillForCreationDTO skillForCreationDTO)
        {
            var createdUserHobby = await skillRepository.CreateAsync(mapper.Map<Skill>(skillForCreationDTO));
            await skillRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await skillRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Skill not found");

            await skillRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Skill>> GetAll(PaginationParams @params, Expression<Func<Skill, bool>> expression = null)
        {
            var skills = skillRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User" });

            return await skills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Skill> GetAsync(Expression<Func<Skill, bool>> expression)
        {
            var skill = await skillRepository.GetAsync(expression, false);

            if (skill is null)
                throw new MyCareerException(404, "Skill not found");

            return skill;
        }

        public async ValueTask<Skill> UpdateAsync(int id, SkillForCreationDTO skillForCreation)
        {
            var existSkill = await skillRepository.GetAsync(f => f.Id == id);

            if (existSkill is null)
                throw new MyCareerException(404, "Skill not found");

            existSkill.UpdatedAt = DateTime.UtcNow;
            existSkill = skillRepository.Update(mapper.Map(skillForCreation, existSkill));
            await skillRepository.SaveChangesAsync();

            return existSkill;
        }
    }
}
