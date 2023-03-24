using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Service.DTOs.Hobbies;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Hobbies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Hobbies
{
    public class HobbyService : IHobbyService
    {
        private readonly IGenericRepository<Hobby> hobbyRepository;
        private readonly IMapper mapper;
        public async ValueTask<Hobby> CreateAsync(HobbyForCreationDTO hobbyForCreationDTO)
        {
            var createdUserHobby = await hobbyRepository.CreateAsync(mapper.Map<Hobby>(hobbyForCreationDTO));
            await hobbyRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await hobbyRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Skill not found");

            await hobbyRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Hobby>> GetAll(PaginationParams @params, Expression<Func<Hobby, bool>> expression = null)
        {
            var skills = hobbyRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User" });

            return await skills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Hobby> GetAsync(Expression<Func<Hobby, bool>> expression)
        {
            var skill = await hobbyRepository.GetAsync(expression, false);

            if (skill is null)
                throw new MyCareerException(404, "UserHobby not found");

            return skill;
        }

        public async ValueTask<Hobby> Update(int id, HobbyForCreationDTO hobbyForCreation)
        {
            var existSkill = await hobbyRepository.GetAsync(f => f.Id == id);

            if (existSkill is null)
                throw new MyCareerException(404, "Talent not found");

            existSkill.UpdatedAt = DateTime.UtcNow;
            existSkill = hobbyRepository.Update(mapper.Map(hobbyForCreation, existSkill));
            await hobbyRepository.SaveChangesAsync();

            return existSkill;
        }
    }
}
