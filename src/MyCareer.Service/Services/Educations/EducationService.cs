using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Domain.Entities.Experiences;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Educations;
using MyCareer.Service.DTOs.Experiences;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Educations
{
    public class EducationService : IEducationService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Education> educationRepository;
        private readonly IMapper mapper;

        public EducationService(IGenericRepository<User> userRepository, IGenericRepository<Education> educationRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.educationRepository = educationRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Education> CreateAsync(EducationForCreationDTO educationForCreationDTO)
        {
            var existUser = await userRepository.GetAsync(
                r => r.Id == educationForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            var createdUserHobby = await educationRepository.CreateAsync(mapper.Map<Education>(educationForCreationDTO));
            await educationRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await educationRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "UserHobby not found");

            await educationRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Education>> GetAll(PaginationParams @params, Expression<Func<Education, bool>> expression = null)
        {
            var esxperinces = educationRepository.GetAll(expression: expression, isTracking: false);

            return await esxperinces.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Education> GetAsync(Expression<Func<Education, bool>> expression)
        {
            var userHobby = await educationRepository.GetAsync(expression, false, new string[] { "User" });

            if (userHobby is null)
                throw new MyCareerException(404, "UserHobby not found");

            return userHobby;
        }

        public async ValueTask<Education> UpdateAsync(int id, EducationForCreationDTO educationForCreationDTO)
        {
            var existExperince = await educationRepository.GetAsync(f => f.Id == id);

            if (existExperince is null)
                throw new MyCareerException(404, "UserHobby not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == educationForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            existExperince.UpdatedAt = DateTime.UtcNow;
            existExperince = educationRepository.Update(mapper.Map(educationForCreationDTO, existExperince));
            await educationRepository.SaveChangesAsync();

            return existExperince;
        }
    }
}
