using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Experiences;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Experiences;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Experiences;

namespace MyCareer.Service.Services.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Experience> experienceRepository;
        private readonly IMapper mapper;

        public ExperienceService(IGenericRepository<User> userRepository, IGenericRepository<Experience> experienceRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.experienceRepository = experienceRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Experience> CreateAsync(ExperienceForCreationDTO experienceForCreationDTO)
        {
            var existUser = await userRepository.GetAsync(
                r => r.Id == experienceForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            var createdUserHobby = await experienceRepository.CreateAsync(mapper.Map<Experience>(experienceForCreationDTO));
            await experienceRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await experienceRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "UserHobby not found");

            await experienceRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Experience>> GetAll(PaginationParams @params, Expression<Func<Experience, bool>> expression = null)
        {
            var esxperinces = experienceRepository.GetAll(expression: expression, isTracking: false);

            return await esxperinces.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Experience> GetAsync(Expression<Func<Experience, bool>> expression)
        {
            var userHobby = await experienceRepository.GetAsync(expression, false, new string[] { "User" });

            if (userHobby is null)
                throw new MyCareerException(404, "UserHobby not found");

            return userHobby;
        }

        public async ValueTask<Experience> UpdateAsync(int id, ExperienceForCreationDTO experienceForCreation)
        {
            var existExperince = await experienceRepository.GetAsync(f => f.Id == id);

            if (existExperince is null)
                throw new MyCareerException(404, "UserHobby not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == experienceForCreation.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            existExperince.UpdatedAt = DateTime.UtcNow;
            existExperince = experienceRepository.Update(mapper.Map(experienceForCreation, existExperince));
            await experienceRepository.SaveChangesAsync();

            return existExperince;
        }
    }
}
