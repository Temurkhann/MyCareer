using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Talents;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Talents;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Talents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Talents
{
    public class TalentService : ITalentService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Talent> talentRepository;
        private readonly IMapper mapper;

        public TalentService(IGenericRepository<User> userRepository, IGenericRepository<Talent> talentRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.talentRepository = talentRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Talent> CreateAsync(TalentForCreationDTO talentForCreationDTO)
        {
            var existUser = await userRepository.GetAsync(
                r => r.Id == talentForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            var createdUserHobby = await talentRepository.CreateAsync(mapper.Map<Talent>(talentForCreationDTO));
            await talentRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await talentRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Talent not found");

            await talentRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Talent>> GetAll(PaginationParams @params, Expression<Func<Talent, bool>> expression = null)
        {
            var talents = talentRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User" });

            return await talents.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Talent> GetAsync(Expression<Func<Talent, bool>> expression)
        {
            var talent = await talentRepository.GetAsync(expression, false, new string[] { "User" });

            if (talent is null)
                throw new MyCareerException(404, "UserHobby not found");

            return talent;
        }

        public async ValueTask<Talent> UpdateAsync(int id, TalentForCreationDTO talentForCreation)
        {
            var existTalent = await talentRepository.GetAsync(f => f.Id == id);

            if (existTalent is null)
                throw new MyCareerException(404, "Talent not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == talentForCreation.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            existTalent.UpdatedAt = DateTime.UtcNow;
            existTalent = talentRepository.Update(mapper.Map(talentForCreation, existTalent));
            await talentRepository.SaveChangesAsync();

            return existTalent;
        }
    }
}
